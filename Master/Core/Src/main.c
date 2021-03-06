/* USER CODE BEGIN Header */
/**
  ******************************************************************************
  * @file           : main.c
  * @brief          : Main program body
  ******************************************************************************
  * @attention
  *
  * <h2><center>&copy; Copyright (c) 2021 STMicroelectronics.
  * All rights reserved.</center></h2>
  *
  * This software component is licensed by ST under BSD 3-Clause license,
  * the "License"; You may not use this file except in compliance with the
  * License. You may obtain a copy of the License at:
  *                        opensource.org/licenses/BSD-3-Clause
  *
  ******************************************************************************
  */
/* USER CODE END Header */
/* Includes ------------------------------------------------------------------*/
#include "main.h"

/* Private includes ----------------------------------------------------------*/
/* USER CODE BEGIN Includes */
#include "rc522.h"
#include "string.h"
/* USER CODE END Includes */

/* Private typedef -----------------------------------------------------------*/
/* USER CODE BEGIN PTD */

/* USER CODE END PTD */

/* Private define ------------------------------------------------------------*/
/* USER CODE BEGIN PD */
/* USER CODE END PD */

/* Private macro -------------------------------------------------------------*/
/* USER CODE BEGIN PM */

/* USER CODE END PM */

/* Private variables ---------------------------------------------------------*/
SPI_HandleTypeDef hspi1;
SPI_HandleTypeDef hspi2;

TIM_HandleTypeDef htim2;

UART_HandleTypeDef huart3;

/* USER CODE BEGIN PV */
uint8_t u8_uart_tx[11];
uint8_t u8_uart_rx[8];

uint8_t u8_spi_tx[11] = "SxxLEDMDxE";
uint8_t u8_spi_rx[11];

uint8_t u8_count_timer = 0;
uint8_t u8_device = '0';
char * devicetemp;

uint8_t u8_LMdata[4] = "0000";
uint8_t u8_modeLed[1];

unsigned char CardID[5];
unsigned char MyID[5] = {0x07, 0x39, 0xB9, 0x3B, 0xBC};
uint8_t nfcFirst = 0;
uint8_t auth[1] = "0";
uint8_t u8_auth_uart_command = 0;
/* USER CODE END PV */

/* Private function prototypes -----------------------------------------------*/
void SystemClock_Config(void);
static void MX_GPIO_Init(void);
static void MX_SPI2_Init(void);
static void MX_USART3_UART_Init(void);
static void MX_TIM2_Init(void);
static void MX_SPI1_Init(void);
static void MX_NVIC_Init(void);
/* USER CODE BEGIN PFP */
void RxSPISetup();
void TxSPISetup(uint8_t device, uint8_t* data,uint8_t from);
void TxUARTSetup(char *device, uint8_t* data);
/* USER CODE END PFP */

/* Private user code ---------------------------------------------------------*/
/* USER CODE BEGIN 0 */
void HAL_UART_RxCpltCallback(UART_HandleTypeDef *huart)
{
	if(huart->Instance == huart3.Instance)
	{
		//0 1 2 6
		//Ph??n t??ch xem truy????n d??? li???u xu???ng cho thi???t b??? n??o
		if(u8_uart_rx[0] == 'S' && u8_uart_rx[6] == 'E')
		{
			//Do khong truyen du lieu toi S1 nen khong viet
			if(u8_uart_rx[1] == 'M' && u8_uart_rx[2] == '1')
			{
				u8_device = '1';
			}
			else if(u8_uart_rx[1] == 'M' && u8_uart_rx[2] == '2')
			{
				u8_device = '2';
			}
			else if(u8_uart_rx[1] == 'S' && u8_uart_rx[2] == '1')
			{
				u8_device = '3';
			}
			else
			{
				u8_device = '0';
			}
		}
		//N???u d??? li???u c?? d???ng MD th?? g???i d??? li???u xu???ng ??i????u khi???n LED
		if(u8_uart_rx[3] == 'M' && u8_uart_rx[4] == 'D')
		{
			u8_modeLed[0] = u8_uart_rx[5];
			TxSPISetup(u8_device, u8_modeLed, 'C');
			if(u8_device == '1')
			{
				HAL_GPIO_WritePin(Slave1_GPIO_Port, Slave1_Pin, 0);
				HAL_SPI_Transmit(&hspi2, u8_spi_tx, 10, 1);
				HAL_GPIO_WritePin(Slave1_GPIO_Port, Slave1_Pin, 1);
				HAL_GPIO_WritePin(Slave1_GPIO_Port, Slave1_Pin, 0);
				HAL_SPI_Transmit(&hspi2, u8_spi_tx, 10, 1);
				HAL_GPIO_WritePin(Slave1_GPIO_Port, Slave1_Pin, 1);
			}
			else if(u8_device == '2')
			{
				//G???i 2 l???n ????? ?????m b???o t??n hi???u qua ?????y ????? (kh????i b???m 2 l???n)
				HAL_GPIO_WritePin(Slave2_GPIO_Port, Slave2_Pin, 0);
				HAL_SPI_Transmit(&hspi2, u8_spi_tx, 10, 100);
				HAL_GPIO_WritePin(Slave2_GPIO_Port, Slave2_Pin, 1);
				HAL_GPIO_WritePin(Slave2_GPIO_Port, Slave2_Pin, 0);
				HAL_SPI_Transmit(&hspi2, u8_spi_tx, 10, 100);
				HAL_GPIO_WritePin(Slave2_GPIO_Port, Slave2_Pin, 1);
			}
		}
		else if(u8_uart_rx[3] == 'P' && u8_uart_rx[4] == 'W')
		{
			u8_modeLed[0] = u8_uart_rx[5];
			TxSPISetup(u8_device, u8_modeLed, 'P');
			HAL_GPIO_WritePin(Slave2_GPIO_Port, Slave2_Pin, 0);
			HAL_SPI_Transmit(&hspi2, u8_spi_tx, 10, 100);
			HAL_GPIO_WritePin(Slave2_GPIO_Port, Slave2_Pin, 1);
			HAL_GPIO_WritePin(Slave2_GPIO_Port, Slave2_Pin, 0);
			HAL_SPI_Transmit(&hspi2, u8_spi_tx, 10, 100);
			HAL_GPIO_WritePin(Slave2_GPIO_Port, Slave2_Pin, 1);
		}
		else if(u8_uart_rx[3] == 'R' && u8_uart_rx[4] == 'F')
		{
			u8_auth_uart_command = u8_uart_rx[5];
		}
	}
	HAL_UART_Receive_IT(&huart3, u8_uart_rx, 7);
}
void HAL_TIM_PeriodElapsedCallback(TIM_HandleTypeDef *htim)
{
	if(htim->Instance == htim2.Instance)
	{
		u8_count_timer++;
		if(u8_count_timer == 5)
		{
			u8_count_timer = 0;
			HAL_GPIO_WritePin(Slave1_GPIO_Port, Slave1_Pin, 0);
			HAL_SPI_TransmitReceive(&hspi2, u8_spi_tx, u8_spi_rx, 10, 1);
			HAL_GPIO_WritePin(Slave1_GPIO_Port, Slave1_Pin, 1);
			RxSPISetup();
			TxUARTSetup("M1",u8_LMdata);
			HAL_UART_Transmit_IT(&huart3, u8_uart_tx, 11);
			TxSPISetup('2', u8_LMdata, 'M');
			HAL_GPIO_WritePin(Slave2_GPIO_Port, Slave2_Pin, 0);
			HAL_SPI_Transmit(&hspi2, u8_spi_tx, 10, 1);
			HAL_GPIO_WritePin(Slave2_GPIO_Port, Slave2_Pin, 1);
		}
	}
}
void TxUARTSetup(char *device, uint8_t* data)
{
	if(strcmp(device, "M1") == 0)
	{
		u8_uart_tx[0] = 'S';
		u8_uart_tx[1] = 'M';
		u8_uart_tx[2] = '1';
		u8_uart_tx[3] = 'L';
		u8_uart_tx[4] = 'M';
		u8_uart_tx[5] = data[0];
		u8_uart_tx[6] = data[1];
		u8_uart_tx[7] = data[2];
		u8_uart_tx[8] = data[3];
		u8_uart_tx[9] = 'E';
		u8_uart_tx[10] = '\n';
	}
	else if(strcmp(device, "S1") == 0)
	{
		u8_uart_tx[0] = 'S';
		u8_uart_tx[1] = 'S';
		u8_uart_tx[2] = '1';
		u8_uart_tx[3] = 'R';
		u8_uart_tx[4] = 'F';
		u8_uart_tx[5] = data[0];
		u8_uart_tx[6] = 'E';
		u8_uart_tx[7] = '\n';

	}
}
void TxSPISetup(uint8_t device, uint8_t* data,uint8_t from)
{
	if(from == 'C')//Computer
	{
		u8_spi_tx[0] = 'S';
		u8_spi_tx[3] = 'L';
		u8_spi_tx[4] = 'E';
		u8_spi_tx[5] = 'D';
		u8_spi_tx[6] = 'M';
		u8_spi_tx[7] = 'D';
		u8_spi_tx[9] = 'E';

		if(device == '1')
		{
			u8_spi_tx[1] = 'M';
			u8_spi_tx[2] = '1';
		}
		else if(device == '2')
		{
			u8_spi_tx[1] = 'M';
			u8_spi_tx[2] = '2';
		}
		u8_spi_tx[8] = data[0];
	}
	else if(from == 'P')
	{
		u8_spi_tx[0] = 'S';
		u8_spi_tx[3] = 'L';
		u8_spi_tx[4] = 'E';
		u8_spi_tx[5] = 'D';
		u8_spi_tx[6] = 'P';
		u8_spi_tx[7] = 'W';
		u8_spi_tx[9] = 'E';
		if(device == '1')
		{
			u8_spi_tx[1] = 'M';
			u8_spi_tx[2] = '1';
		}
		else if(device == '2')
		{
			u8_spi_tx[1] = 'M';
			u8_spi_tx[2] = '2';
		}
		u8_spi_tx[8] = data[0];
	}
	else
	{
		u8_spi_tx[0] = 'S';
		u8_spi_tx[1] = 'M';
		u8_spi_tx[2] = '1';
		u8_spi_tx[3] = 'L';
		u8_spi_tx[4] = 'M';
		u8_spi_tx[9] = 'E';
		if(device == '2')
		{
			u8_spi_tx[5] = data[0];
			u8_spi_tx[6] = data[1];
			u8_spi_tx[7] = data[2];
			u8_spi_tx[8] = data[3];
		}
	}

}
void RxSPISetup()
{
	if(u8_spi_rx[0] == 'S' && u8_spi_rx[9] == 'E')
	{
		u8_LMdata[0] = u8_spi_rx[5];
		u8_LMdata[1] = u8_spi_rx[6];
		u8_LMdata[2] = u8_spi_rx[7];
		u8_LMdata[3] = u8_spi_rx[8];
	}
}
/* USER CODE END 0 */

/**
  * @brief  The application entry point.
  * @retval int
  */
int main(void)
{
  /* USER CODE BEGIN 1 */

  /* USER CODE END 1 */

  /* MCU Configuration--------------------------------------------------------*/

  /* Reset of all peripherals, Initializes the Flash interface and the Systick. */
  HAL_Init();

  /* USER CODE BEGIN Init */

  /* USER CODE END Init */

  /* Configure the system clock */
  SystemClock_Config();

  /* USER CODE BEGIN SysInit */

  /* USER CODE END SysInit */

  /* Initialize all configured peripherals */
  MX_GPIO_Init();
  MX_SPI2_Init();
  MX_USART3_UART_Init();
  MX_TIM2_Init();
  MX_SPI1_Init();

  /* Initialize interrupts */
  MX_NVIC_Init();
  /* USER CODE BEGIN 2 */
  HAL_SPI_Init(&hspi1);
  HAL_SPI_Init(&hspi2);
  HAL_UART_Init(&huart3);
  //HAL_TIM_Base_Init(&htim2);
  HAL_TIM_Base_Start_IT(&htim2);
  MFRC522_Init();
  /* USER CODE END 2 */

  /* Infinite loop */
  /* USER CODE BEGIN WHILE */
  HAL_UART_Receive_IT(&huart3, u8_uart_rx, 7);
  while (1)
  {
	  if(u8_device == '3' && u8_auth_uart_command == '1')
	  {
		  if (MFRC522_Check(CardID) == MI_OK && nfcFirst == 0)
		  {
			nfcFirst = 1;
			HAL_GPIO_TogglePin(LED_GPIO_Port, LED_Pin);
			if (MFRC522_Compare(CardID, MyID) == MI_OK )
			{
				auth[0] = '1';
				TxUARTSetup("S1", auth);
				HAL_UART_Transmit_IT(&huart3, u8_uart_tx, 8);
			}
		  }
		  else if(MFRC522_Check(CardID) != MI_OK)
		  {
			  auth[0] = '0';
			  nfcFirst = 0;
		  }
	  }

	  HAL_Delay(10);
    /* USER CODE END WHILE */

    /* USER CODE BEGIN 3 */
  }
  /* USER CODE END 3 */
}

/**
  * @brief System Clock Configuration
  * @retval None
  */
void SystemClock_Config(void)
{
  RCC_OscInitTypeDef RCC_OscInitStruct = {0};
  RCC_ClkInitTypeDef RCC_ClkInitStruct = {0};

  /** Initializes the RCC Oscillators according to the specified parameters
  * in the RCC_OscInitTypeDef structure.
  */
  RCC_OscInitStruct.OscillatorType = RCC_OSCILLATORTYPE_HSE;
  RCC_OscInitStruct.HSEState = RCC_HSE_ON;
  RCC_OscInitStruct.HSEPredivValue = RCC_HSE_PREDIV_DIV1;
  RCC_OscInitStruct.HSIState = RCC_HSI_ON;
  RCC_OscInitStruct.PLL.PLLState = RCC_PLL_ON;
  RCC_OscInitStruct.PLL.PLLSource = RCC_PLLSOURCE_HSE;
  RCC_OscInitStruct.PLL.PLLMUL = RCC_PLL_MUL9;
  if (HAL_RCC_OscConfig(&RCC_OscInitStruct) != HAL_OK)
  {
    Error_Handler();
  }
  /** Initializes the CPU, AHB and APB buses clocks
  */
  RCC_ClkInitStruct.ClockType = RCC_CLOCKTYPE_HCLK|RCC_CLOCKTYPE_SYSCLK
                              |RCC_CLOCKTYPE_PCLK1|RCC_CLOCKTYPE_PCLK2;
  RCC_ClkInitStruct.SYSCLKSource = RCC_SYSCLKSOURCE_PLLCLK;
  RCC_ClkInitStruct.AHBCLKDivider = RCC_SYSCLK_DIV1;
  RCC_ClkInitStruct.APB1CLKDivider = RCC_HCLK_DIV2;
  RCC_ClkInitStruct.APB2CLKDivider = RCC_HCLK_DIV1;

  if (HAL_RCC_ClockConfig(&RCC_ClkInitStruct, FLASH_LATENCY_2) != HAL_OK)
  {
    Error_Handler();
  }
}

/**
  * @brief NVIC Configuration.
  * @retval None
  */
static void MX_NVIC_Init(void)
{
  /* SPI2_IRQn interrupt configuration */
  HAL_NVIC_SetPriority(SPI2_IRQn, 0, 0);
  HAL_NVIC_EnableIRQ(SPI2_IRQn);
  /* USART3_IRQn interrupt configuration */
  HAL_NVIC_SetPriority(USART3_IRQn, 0, 0);
  HAL_NVIC_EnableIRQ(USART3_IRQn);
  /* TIM2_IRQn interrupt configuration */
  HAL_NVIC_SetPriority(TIM2_IRQn, 0, 0);
  HAL_NVIC_EnableIRQ(TIM2_IRQn);
}

/**
  * @brief SPI1 Initialization Function
  * @param None
  * @retval None
  */
static void MX_SPI1_Init(void)
{

  /* USER CODE BEGIN SPI1_Init 0 */

  /* USER CODE END SPI1_Init 0 */

  /* USER CODE BEGIN SPI1_Init 1 */

  /* USER CODE END SPI1_Init 1 */
  /* SPI1 parameter configuration*/
  hspi1.Instance = SPI1;
  hspi1.Init.Mode = SPI_MODE_MASTER;
  hspi1.Init.Direction = SPI_DIRECTION_2LINES;
  hspi1.Init.DataSize = SPI_DATASIZE_8BIT;
  hspi1.Init.CLKPolarity = SPI_POLARITY_LOW;
  hspi1.Init.CLKPhase = SPI_PHASE_1EDGE;
  hspi1.Init.NSS = SPI_NSS_SOFT;
  hspi1.Init.BaudRatePrescaler = SPI_BAUDRATEPRESCALER_8;
  hspi1.Init.FirstBit = SPI_FIRSTBIT_MSB;
  hspi1.Init.TIMode = SPI_TIMODE_DISABLE;
  hspi1.Init.CRCCalculation = SPI_CRCCALCULATION_DISABLE;
  hspi1.Init.CRCPolynomial = 10;
  if (HAL_SPI_Init(&hspi1) != HAL_OK)
  {
    Error_Handler();
  }
  /* USER CODE BEGIN SPI1_Init 2 */

  /* USER CODE END SPI1_Init 2 */

}

/**
  * @brief SPI2 Initialization Function
  * @param None
  * @retval None
  */
static void MX_SPI2_Init(void)
{

  /* USER CODE BEGIN SPI2_Init 0 */

  /* USER CODE END SPI2_Init 0 */

  /* USER CODE BEGIN SPI2_Init 1 */

  /* USER CODE END SPI2_Init 1 */
  /* SPI2 parameter configuration*/
  hspi2.Instance = SPI2;
  hspi2.Init.Mode = SPI_MODE_MASTER;
  hspi2.Init.Direction = SPI_DIRECTION_2LINES;
  hspi2.Init.DataSize = SPI_DATASIZE_8BIT;
  hspi2.Init.CLKPolarity = SPI_POLARITY_LOW;
  hspi2.Init.CLKPhase = SPI_PHASE_1EDGE;
  hspi2.Init.NSS = SPI_NSS_SOFT;
  hspi2.Init.BaudRatePrescaler = SPI_BAUDRATEPRESCALER_16;
  hspi2.Init.FirstBit = SPI_FIRSTBIT_MSB;
  hspi2.Init.TIMode = SPI_TIMODE_DISABLE;
  hspi2.Init.CRCCalculation = SPI_CRCCALCULATION_DISABLE;
  hspi2.Init.CRCPolynomial = 10;
  if (HAL_SPI_Init(&hspi2) != HAL_OK)
  {
    Error_Handler();
  }
  /* USER CODE BEGIN SPI2_Init 2 */

  /* USER CODE END SPI2_Init 2 */

}

/**
  * @brief TIM2 Initialization Function
  * @param None
  * @retval None
  */
static void MX_TIM2_Init(void)
{

  /* USER CODE BEGIN TIM2_Init 0 */

  /* USER CODE END TIM2_Init 0 */

  TIM_ClockConfigTypeDef sClockSourceConfig = {0};
  TIM_MasterConfigTypeDef sMasterConfig = {0};

  /* USER CODE BEGIN TIM2_Init 1 */

  /* USER CODE END TIM2_Init 1 */
  htim2.Instance = TIM2;
  htim2.Init.Prescaler = 35999;
  htim2.Init.CounterMode = TIM_COUNTERMODE_UP;
  htim2.Init.Period = 1999;
  htim2.Init.ClockDivision = TIM_CLOCKDIVISION_DIV1;
  htim2.Init.AutoReloadPreload = TIM_AUTORELOAD_PRELOAD_DISABLE;
  if (HAL_TIM_Base_Init(&htim2) != HAL_OK)
  {
    Error_Handler();
  }
  sClockSourceConfig.ClockSource = TIM_CLOCKSOURCE_INTERNAL;
  if (HAL_TIM_ConfigClockSource(&htim2, &sClockSourceConfig) != HAL_OK)
  {
    Error_Handler();
  }
  sMasterConfig.MasterOutputTrigger = TIM_TRGO_RESET;
  sMasterConfig.MasterSlaveMode = TIM_MASTERSLAVEMODE_DISABLE;
  if (HAL_TIMEx_MasterConfigSynchronization(&htim2, &sMasterConfig) != HAL_OK)
  {
    Error_Handler();
  }
  /* USER CODE BEGIN TIM2_Init 2 */

  /* USER CODE END TIM2_Init 2 */

}

/**
  * @brief USART3 Initialization Function
  * @param None
  * @retval None
  */
static void MX_USART3_UART_Init(void)
{

  /* USER CODE BEGIN USART3_Init 0 */

  /* USER CODE END USART3_Init 0 */

  /* USER CODE BEGIN USART3_Init 1 */

  /* USER CODE END USART3_Init 1 */
  huart3.Instance = USART3;
  huart3.Init.BaudRate = 115200;
  huart3.Init.WordLength = UART_WORDLENGTH_8B;
  huart3.Init.StopBits = UART_STOPBITS_1;
  huart3.Init.Parity = UART_PARITY_NONE;
  huart3.Init.Mode = UART_MODE_TX_RX;
  huart3.Init.HwFlowCtl = UART_HWCONTROL_NONE;
  huart3.Init.OverSampling = UART_OVERSAMPLING_16;
  if (HAL_UART_Init(&huart3) != HAL_OK)
  {
    Error_Handler();
  }
  /* USER CODE BEGIN USART3_Init 2 */

  /* USER CODE END USART3_Init 2 */

}

/**
  * @brief GPIO Initialization Function
  * @param None
  * @retval None
  */
static void MX_GPIO_Init(void)
{
  GPIO_InitTypeDef GPIO_InitStruct = {0};

  /* GPIO Ports Clock Enable */
  __HAL_RCC_GPIOC_CLK_ENABLE();
  __HAL_RCC_GPIOD_CLK_ENABLE();
  __HAL_RCC_GPIOA_CLK_ENABLE();
  __HAL_RCC_GPIOB_CLK_ENABLE();

  /*Configure GPIO pin Output Level */
  HAL_GPIO_WritePin(LED_GPIO_Port, LED_Pin, GPIO_PIN_RESET);

  /*Configure GPIO pin Output Level */
  HAL_GPIO_WritePin(GPIOA, GPIO_PIN_4, GPIO_PIN_RESET);

  /*Configure GPIO pin Output Level */
  HAL_GPIO_WritePin(GPIOA, Slave1_Pin|Slave2_Pin, GPIO_PIN_SET);

  /*Configure GPIO pin : LED_Pin */
  GPIO_InitStruct.Pin = LED_Pin;
  GPIO_InitStruct.Mode = GPIO_MODE_OUTPUT_PP;
  GPIO_InitStruct.Pull = GPIO_NOPULL;
  GPIO_InitStruct.Speed = GPIO_SPEED_FREQ_LOW;
  HAL_GPIO_Init(LED_GPIO_Port, &GPIO_InitStruct);

  /*Configure GPIO pin : PA4 */
  GPIO_InitStruct.Pin = GPIO_PIN_4;
  GPIO_InitStruct.Mode = GPIO_MODE_OUTPUT_PP;
  GPIO_InitStruct.Pull = GPIO_NOPULL;
  GPIO_InitStruct.Speed = GPIO_SPEED_FREQ_LOW;
  HAL_GPIO_Init(GPIOA, &GPIO_InitStruct);

  /*Configure GPIO pins : Slave1_Pin Slave2_Pin */
  GPIO_InitStruct.Pin = Slave1_Pin|Slave2_Pin;
  GPIO_InitStruct.Mode = GPIO_MODE_OUTPUT_PP;
  GPIO_InitStruct.Pull = GPIO_NOPULL;
  GPIO_InitStruct.Speed = GPIO_SPEED_FREQ_HIGH;
  HAL_GPIO_Init(GPIOA, &GPIO_InitStruct);

}

/* USER CODE BEGIN 4 */

/* USER CODE END 4 */

/**
  * @brief  This function is executed in case of error occurrence.
  * @retval None
  */
void Error_Handler(void)
{
  /* USER CODE BEGIN Error_Handler_Debug */
  /* User can add his own implementation to report the HAL error return state */
  __disable_irq();
  while (1)
  {
  }
  /* USER CODE END Error_Handler_Debug */
}

#ifdef  USE_FULL_ASSERT
/**
  * @brief  Reports the name of the source file and the source line number
  *         where the assert_param error has occurred.
  * @param  file: pointer to the source file name
  * @param  line: assert_param error line source number
  * @retval None
  */
void assert_failed(uint8_t *file, uint32_t line)
{
  /* USER CODE BEGIN 6 */
  /* User can add his own implementation to report the file name and line number,
     ex: printf("Wrong parameters value: file %s on line %d\r\n", file, line) */
  /* USER CODE END 6 */
}
#endif /* USE_FULL_ASSERT */

/************************ (C) COPYRIGHT STMicroelectronics *****END OF FILE****/

Version 1.0

Documentation PDF: 
SDK: .NET Core 6.0

Encryption Algorithm: https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.aes?view=net-6.0
Key: Emtelco-IVR@2022

url swagger: https://apicloud.emtelco.co/Tuya/api_tuya/swagger/index.html

usuario token:
{
  "userName": "api_tuya@emtelco.com.co",
  "password": "4nUpi-M33iSE"
}
decorador: api_tuya

*******************************************************************************************************************************************
DatosTarjetaCliente

url api: https://apicloud.emtelco.co/Tuya/api_tuya/api/v1/DatosTarjetaCliente

json entrada:
{
  "cedula": "1015403539",
  "interactionId": "string"
}

json salida
{
	"response": {
		"respuesta_ws": {
			"encontro_informacion": true,
			"encontro_informacion_billetera": true,
			"tarjetas": [
				{
					"orden": 1,
					"codigo_negocio": "612",
					"obligacion": "0002660000037443414",
					"numero_tarjeta_completo": "0002660000017443414",
					"numero_tarjeta": "3414",
					"nombre_producto": "MASTERCARD TARJETA DIGITAL",
					"estado": null,
					"numero_documento": "1015403539",
					"nombre_usuario": "DEL CAMPO MATALLANA ANA CAROLINA",
					"condiciones": [
						{
							"codigo_condicion": "",
							"observaciones": "",
							"transaccion": ""
						}
					],
					"datos_factura": {
						"ciclo_facturacion": null,
						"referente_pago": null,
						"valor_pago_minimo": "455121.88",
						"valor_pago_total": "775955.21",
						"fecha_limite_pago": "20231003",
						"fecha_proyectada_pago": "20231003",
						"dias_de_mora": "0",
						"codigo_resultado": "OK",
						"tiempo_procesamiento": "1047 ms",
						"error": null
					},
					"estado_cuenta": "A",
					"codigo_producto": "612",
					"dias_no_uso": "",
					"numCuenta": "0008306125309802907",
					"bim_tajerta": "266000",
					"tarjeta_adicional_fisica": "N",
					"tarjeta_adicional_digital": "Y",
					"tarjeta_adicional": "",
					"tipo_tarjeta": "Tarjeta Franquicia",
					"estadoTarjeta": "0",
					"requiereActivacion": "N",
					"codigo_bloqueo_tarjeta": "",
					"codigo_bloqueo_cuenta_1": "",
					"codigo_bloqueo_cuenta_2": "",
					"cupos_tarjeta": {
						"codigo_resultado": "OK",
						"tiempo_procesamiento": "1163 ms",
						"cupo_disponible_avance": "224044.79",
						"cupo_disponible_compra": "224044.79",
						"cupo_compra": "1000000.00",
						"cupo_avance": "1000000.00",
						"error": null
					}
				},								
				{
					"orden": 23,
					"codigo_negocio": "914",
					"obligacion": "00000009140004860",
					"numero_tarjeta_completo": "5903130003293180",
					"numero_tarjeta": "3180",
					"nombre_producto": "CREDITO EMPL.LIBRE INVER EXITO",
					"estado": null,
					"numero_documento": "1015403539",
					"nombre_usuario": "DEL CAMPO MATALLANA ANA CAROLINA",
					"condiciones": [
						{
							"codigo_condicion": "",
							"observaciones": "",
							"transaccion": ""
						}
					],
					"datos_factura": {
						"ciclo_facturacion": null,
						"referente_pago": null,
						"valor_pago_minimo": null,
						"valor_pago_total": null,
						"fecha_limite_pago": null,
						"fecha_proyectada_pago": null,
						"dias_de_mora": null,
						"codigo_resultado": "OK",
						"tiempo_procesamiento": "656 ms",
						"error": null
					},
					"estado_cuenta": "001",
					"codigo_producto": "914",
					"dias_no_uso": "",
					"numCuenta": "00000009140004860",
					"bim_tajerta": "590313",
					"tarjeta_adicional_fisica": "",
					"tarjeta_adicional_digital": "",
					"tarjeta_adicional": "N",
					"tipo_tarjeta": "TarjetaPrivada",
					"estadoTarjeta": "0",
					"requiereActivacion": "",
					"codigo_bloqueo_tarjeta": "",
					"codigo_bloqueo_cuenta_1": "",
					"codigo_bloqueo_cuenta_2": "",
					"cupos_tarjeta": {
						"codigo_resultado": "OK",
						"tiempo_procesamiento": "725 ms",
						"cupo_disponible_avance": "800000",
						"cupo_disponible_compra": "79139494",
						"cupo_compra": "223000000",
						"cupo_avance": null,
						"error": null
					}
				}
			],
			"billetera": {
				"codigo_negocio": "NOR",
				"estado": "NOR",
				"nombre_producto": "Tuya Pay",
				"nombre_usuario": "DEL CAMPO  ANA CAROLINA",
				"numero_celular": "3186788363",
				"codigo_resultado": "OK",
				"tiempo_procesamiento": "257 ms",
				"error": null
			},
			"body_servicio_tuya": null,
			"cliente_consultado": {
				"cedula": "1015403539",
				"nombre": "DEL CAMPO MATALLANA ANA CAROLINA",
				"tarjetasConsultadas": [
					{
						"numeroTarjeta": "0002660000017443414",
						"servicios": [
							{
								"nombre": "ObtenerCupoDisponibleClienteMC2",
								"resultado": "OK",
								"tiempo": "1163 ms",
								"error": null
							},
							{
								"nombre": "ObtenerValoresPagoTarjetaMC2",
								"resultado": "OK",
								"tiempo": "1047 ms",
								"error": null
							}
						],
						"orden": 1
					},					
					{
						"numeroTarjeta": "5903130003293180",
						"servicios": [
							{
								"nombre": "ConsultarCuposTarjeta",
								"resultado": "OK",
								"tiempo": "725 ms",
								"error": null
							},
							{
								"nombre": "ConsultarValoresPago",
								"resultado": "OK",
								"tiempo": "656 ms",
								"error": null
							}
						],
						"orden": 23
					}
				],
				"serviciosCliente": [
					{
						"nombre": "GenerarCuentaDigital",
						"resultado": "OK",
						"tiempo": "257 ms",
						"error": null
					},
					{
						"nombre": "VerificarCedula",
						"resultado": "OK",
						"tiempo": "1792 ms",
						"error": null
					}
				]
			},
			"verificacion_interna_cedula": {
				"cedula_bloqueado_asesor": false,
				"producto_nuevo_sin_usos": false,
				"codigo_resultado": "OK",
				"tiempo_procesamiento": "1792 ms"
			}
		}
	},
	"time": "7843 ms",
	"result": true,
	"errors": "",
	"status": 200
}

Metodos internos del cliente:

Nombre: GenerarDatosClienteUnicoRest
Tipo: REST-POST
url cliente: https://apity.tuya.com.co/Private/TransversalesConsultaProducto/V1.0/api/ConsultProduct/v1/GetAllProducts
json entrada:
{
	"channel": 20,
	"documentType": 1,
	"document": "1015403539"
}
Headers:
Content-Type -> application/json
Ocp-Apim-Subscription-Key -> b4272d180069473d92725ea9bef35fca
Descripcion: Sirve para consultar la información basica de los productos del cliente
Developed By: Wilmar Alejandro Gutierrez Ramirez
_______________________________________________________________________________________________
Nombre: ConsultarCuposTarjeta
Tipo: SOAP
url cliente: https://172.16.20.20:7083/intf/fw/ChannelAdapter/V1.0
Xml entrada:
<soapenv:Envelope
	xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/"
	xmlns:v1="http://www.tuya.com.co/xsd/common/header/V1"
	xmlns:v11="http://tuya.com.co/Core/V1">
	<soapenv:Header>
		<v1:cabeceraRequest>
			<v1:sistema>?</v1:sistema>
			<v1:idCorrelacion>?</v1:idCorrelacion>
			<v1:fechaInvocacion>?</v1:fechaInvocacion>
			<v1:credenciales>
				<v1:usuario>?</v1:usuario>
				<v1:password>?</v1:password>
			</v1:credenciales>
			<v1:locacion>
				<v1:servicio>?</v1:servicio>
				<v1:namespace>?</v1:namespace>
				<v1:operacion>?</v1:operacion>
			</v1:locacion>
		</v1:cabeceraRequest>
	</soapenv:Header>
	<soapenv:Body>
		<v11:ConsultarCuposTarjeta>
			<!--Optional:-->
			<v11:input>
				<!--Optional:-->
				<v11:AplicacionOrigen>IVR</v11:AplicacionOrigen>
				<!--Optional:-->
				<v11:EnviaTipoCliente>false</v11:EnviaTipoCliente>
				<!--Optional:-->
				<v11:NroNegocio>{codigoNegocio}</v11:NroNegocio>
				<v11:NroTarjeta>{numeroTarjetaCliente}</v11:NroTarjeta>
				<!--Optional:-->
				<v11:Tipo>0</v11:Tipo>
				<!--Optional:-->
				<v11:TipoCliente>ClienteTarjetaPrivada</v11:TipoCliente>
			</v11:input>
		</v11:ConsultarCuposTarjeta>
	</soapenv:Body>
</soapenv:Envelope>

Descripcion: Se utiliza para consultar el cupo de una tarjeta cuando es PRIVADA
Developed By: Wilmar Alejandro Gutierrez Ramirez
_______________________________________________________________________________________________
Nombre: ConsultarValoresPago
Tipo: SOAP
url cliente: https://172.16.20.20:7083/intf/fw/ChannelAdapter/V1.0
Xml entrada:
<soapenv:Envelope
	xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/"
	xmlns:v1="http://www.tuya.com.co/xsd/common/header/V1"
	xmlns:v11="http://tuya.com.co/Core/V1">
	<soapenv:Header>
		<v1:cabeceraRequest>
			<v1:sistema>?</v1:sistema>
			<v1:idCorrelacion>?</v1:idCorrelacion>
			<v1:fechaInvocacion>?</v1:fechaInvocacion>
			<v1:credenciales>
				<v1:usuario>?</v1:usuario>
				<v1:password>?</v1:password>
			</v1:credenciales>
			<v1:locacion>
				<v1:servicio>?</v1:servicio>
				<v1:namespace>?</v1:namespace>
				<v1:operacion>?</v1:operacion>
			</v1:locacion>
		</v1:cabeceraRequest>
	</soapenv:Header>
	<soapenv:Body>
		<v11:ConsultarValoresPago>
			<!--Optional:-->
			<v11:input>
				<!--Optional:-->
				<v11:AplicacionOrigen>IVR</v11:AplicacionOrigen>
				<!--Optional:-->
				<v11:EnviaTipoCliente>false</v11:EnviaTipoCliente>
				<!--Optional:-->
				<v11:FechaConsulta>2023-09-04T20:02:00</v11:FechaConsulta>
				<v11:NroNegocio>404</v11:NroNegocio>
				<!--Optional:-->
				<v11:NroTarjeta>{numeroTarjetaCliente}</v11:NroTarjeta>
				<!--Optional:-->
				<v11:RetornaDiasMora>true</v11:RetornaDiasMora>
				<!--Optional:-->
				<v11:Tipo>0</v11:Tipo>
				<!--Optional:-->
				<v11:TipoCliente>ClienteTarjetaPrivada</v11:TipoCliente>
				<!--Optional:-->
				<v11:TipoProyeccion>ProyectarConFechaSistema</v11:TipoProyeccion>
			</v11:input>
		</v11:ConsultarValoresPago>
	</soapenv:Body>
</soapenv:Envelope>

Descripcion: Se utiliza para consultar los valores pagos de la tarjeta cuando es PRIVADA
Developed By: Wilmar Alejandro Gutierrez Ramirez
_______________________________________________________________________________________________
Nombre: ObtenerCupoDisponibleClienteMC2
Tipo: SOAP
url cliente: https://172.16.20.20:7083/intf/fw/ChannelAdapter/V2.0
Xml entrada:
<soapenv:Envelope
	xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/"
	xmlns:v1="http://www.tuya.com.co/xsd/common/header/V1"
	xmlns:v11="http://www.tuya.com.co/xsd/cns/ConsultaCuposTarjeta/V1">
	<soapenv:Header>
		<v1:cabeceraRequest>
			<v1:sistema>FV</v1:sistema>
			<v1:idCorrelacion>IVR2023-09-04T20:02:00</v1:idCorrelacion>
			<v1:fechaInvocacion>2023-09-04T20:02:00</v1:fechaInvocacion>
			<v1:credenciales>
				<v1:usuario>?</v1:usuario>
				<v1:password>?</v1:password>
			</v1:credenciales>
			<v1:locacion>
				<v1:servicio>ConsultaCuposTarjeta</v1:servicio>
                <v1:namespace>http://www.tuya.com.co/xsd/cns/ConsultaCuposTarjeta/V1</v1:namespace>
				<v1:operacion>obtenerCuposTarjeta</v1:operacion>
			</v1:locacion>
		</v1:cabeceraRequest>
	</soapenv:Header>
	<soapenv:Body>
		<v11:obtenerCuposTarjeta>
			<!--Optional:-->
			<organizacion>830</organizacion>
			<numeroTarjeta>{numeroTarjetaCliente}</numeroTarjeta>
			<!--Optional:-->
			<indicadorUsoExterior>0</indicadorUsoExterior>
			<!--Optional:-->
			<codigoCanal>4</codigoCanal>
			<!--Optional:-->
			<codigoTransaccion>002</codigoTransaccion>
		</v11:obtenerCuposTarjeta>
	</soapenv:Body>
</soapenv:Envelope>

Descripcion: Se utiliza para consultar los cupos de la tarjeta cuando es MASTERCARD
Developed By: Wilmar Alejandro Gutierrez Ramirez
_______________________________________________________________________________________________
Nombre: ObtenerValoresPagoTarjetaMC2
Tipo: SOAP
url cliente: https://172.16.20.20:7083/intf/fw/ChannelAdapter/V2.0
Xml entrada:
<soapenv:Envelope
	xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/"
	xmlns:v1="http://www.tuya.com.co/xsd/common/header/V1"
	xmlns:v11="http://www.tuya.com.co/xsd/cns/ConsultaValoresPago/V1">
	<soapenv:Header>
		<v1:cabeceraRequest>
			<v1:sistema>FV</v1:sistema>
			<v1:idCorrelacion>IVR2023-09-04T20:02:00</v1:idCorrelacion>
			<v1:fechaInvocacion>2017-10-30 10:45:30.59</v1:fechaInvocacion>
			<v1:credenciales>
				<v1:usuario>?</v1:usuario>
				<v1:password>?</v1:password>
			</v1:credenciales>
			<v1:locacion>
				<v1:servicio>ConsultaValoresPago</v1:servicio>
				<v1:namespace>http://www.tuya.com.co/xsd/cns/ConsultaValoresPago/V1</v1:namespace>
				<v1:operacion>obtenerValoresPago</v1:operacion>
			</v1:locacion>
		</v1:cabeceraRequest>
	</soapenv:Header>
	<soapenv:Body>
		<v11:obtenerValoresPago>
			<numeroTarjeta>{numeroTarjetaCliente}</numeroTarjeta>
			<codigoCanal>1</codigoCanal>
			<codigoTransaccion>008</codigoTransaccion>
		</v11:obtenerValoresPago>
	</soapenv:Body>
</soapenv:Envelope>

Descripcion: Se utiliza para consultar los valores de la tarjeta cuando es MASTERCARD
Developed By: Wilmar Alejandro Gutierrez Ramirez
_______________________________________________________________________________________________
Nombre: GenerarCuentaDigital
Tipo: REST-GET
url cliente: https://apity.tuya.com.co/Partner/TuyapayCustomerQuery/V1.0/api/CustomerQuery
json salida:
{
	"name": "LOPEZ SANCHEZ ELIZABETH",
	"walletId": "3196985385",
	"state": "NOR"
}
Headers:
DocumentNumber -> 1038770746
DocumentType -> 1
Ocp-Apim-Subscription-Key -> b4272d180069473d92725ea9bef35fca
Descripcion: Sirve para consultar la información de billetera del cliente
Developed By: Wilmar Alejandro Gutierrez Ramirez
_______________________________________________________________________________________________
Nombre: VerificarCedula
Tipo: BASE DE DATOS
server: 10.1.9.50
bd: DB_Tuya_Genesys
user: App_tuya_genesys
tabla: ValoresYlistasTuyas
Descripcion: Consulta ue se realiza a la tabla en cuestión para mirar si ListOption = 1 entonces cedula_bloqueo_asesor es true, si ListOption = 2 entonces producto_nuevo_sin_usos es true
Developed By: Wilmar Alejandro Gutierrez Ramirez
*****************************************************************************************************************************************************************


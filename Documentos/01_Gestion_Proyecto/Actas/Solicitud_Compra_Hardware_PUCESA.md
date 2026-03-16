# DOCUMENTO FORMAL: SOLICITUD DE REQUERIMIENTOS TÉCNICOS PARA RENOVACIÓN DE INFRAESTRUCTURA DE HARDWARE

**Proyecto:** Sistema de Gestión de Parqueaderos PUCESA (SGP)
**Emitido por:** Equipo de Desarrollo e Ingeniería SGP
**Dirigido a:** Dirección Administrativa / Departamento de Adquisiciones PUCESA
**Fecha de Emisión:** 16 de Marzo de 2026

---

## 1. Propósito del Documento
El presente documento tiene como objetivo presentar formalmente la lista de materiales, periféricos y componentes de infraestructura electrónica requeridos para la modernización y estandarización del hardware de control vehicular en las instalaciones de la Pontificia Universidad Católica del Ecuador Sede Ambato (PUCESA). 

La adquisición e instalación de estos equipos es un requisito técnico indispensable para asegurar la compatibilidad con el nuevo Sistema de Gestión de Parqueaderos (SGP) y garantizar un flujo vehicular automatizado seguro y eficiente.

---

## 2. Especificaciones Técnicas de Adquisición

A continuación, se detalla el catálogo de equipos homologados y recomendados por el equipo de ingeniería para su proceso de compra.

### A. Sensores y Lectura Biomédica (Identificación)
| Ítem | Cantidad | Descripción Técnica y Marca Recomendada | Destino/Uso |
| :---: | :---: | :--- | :--- |
| **01** | 2 | **Antena Lector de Tags RFID UHF**<br>Modelo: *UHF10F Pro* | Detección vehicular a distancia. |
| **02** | 2 | **Pedestal / Brazo Estructural** | Montaje y soporte exterior de antenas. |
| **03** | 1 | **Lector Óptico de Integración (2D)**<br>Modelo: *SC505 (2D Desktop Barcode Scanner)*<br>Marca: *3nStar* | Escáner de tickets QR/Barras para garita. |

### B. Detección Perimetral y Seguridad Física
| Ítem | Cantidad | Descripción Técnica y Marca Recomendada | Destino/Uso |
| :---: | :---: | :--- | :--- |
| **04** | 3 | **Sensores de Masa Vehicular (Lazo Magnético)**<br>Modelo: *PSA02-B (Loop de Piso)*<br>Marca: *ZKTeco* | Detección de chasis metálico para control anti-aplastamiento de plumas. |
| **05** | 3 | **Electroimán / Chapa Eléctrica de Seguridad** | - (1) Asignada a Facultad de Medicina<br>- (2) Asignadas al Coliseo |

### C. Acondicionamiento Eléctrico y Energía 
| Ítem | Cantidad | Descripción Técnica y Marca Recomendada | Destino/Uso |
| :---: | :---: | :--- | :--- |
| **06** | 1 | **Sistema de Alimentación Ininterrumpida (UPS)**<br>Modelo: *BV1000*<br>Marca: *APC by Schneider Electric* | Respaldo energético crítico ante cortes de luz. |
| **07** | 1 | **Fuente de Poder Conmutada Central (12V)**<br>Modelo: *TPS-1285*<br>Marca: *EVL* (Certificación CE) | Conversión regulada de energía para actuadores. |

### D. Componentes Activos de Integración (Circuitos)
| Ítem | Cantidad | Descripción Técnica y Marca Recomendada | Destino/Uso |
| :---: | :---: | :--- | :--- |
| **08** | 1 | **Bloque de Terminales / Regleta de Conexión**<br>Especificación: 6 Entradas x 6 Salidas | Distribución de cableado I/O. |
| **09** | 2 | **Terminal de Aislamiento de Circuito**<br>Modelo: *Square D M6/8*<br>Clasificación: *300V* | Protección contra sobrecargas. |
| **10** | 2 | **Cajetines de Empotramiento** | Resguardo de circuitos exteriores. |
| **11** | 2 | **Pulsador / Interruptor Tipo Timbre** | Apertura/Acción manual en garita. |

### E. Cableado Estructurado
| Ítem | Cantidad | Descripción Técnica y Marca Recomendada | Destino/Uso |
| :---: | :---: | :--- | :--- |
| **12** | 1 (Rollo) | **Cable Estructurado de Red (Ethernet)**<br>Especificación: *UTP Largo (Cat6 Recomendado)* | Enlace TCP/IP entre la garita y los controladores. |

---

## 3. Justificación y Recomendaciones de Ingeniería
*   **Compatibilidad:** Los modelos listados (especialmente ZKTeco y UHF10F Pro) han sido validados previamente en el entorno de pruebas del proyecto SGP para garantizar comunicación sin latencia vía SDK y red.
*   **Certificación CE:** La recomendación de marcas como EVL o APC busca prevenir fallos eléctricos o cortos que dañen la infraestructura de las tarjetas controladoras InBIO, alargando la vida útil del sistema.
*   **Soporte Técnico:** Al momento de adquirir los equipos mencionados, asegúrese de solicitar al proveedor la garantía por escrito y datasheets de configuración.

Atentamente,

**Equipo de Desarrollo e Ingeniería**
*Proyecto SGP PUCESA*

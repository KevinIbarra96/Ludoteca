-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versión del servidor:         8.0.29 - MySQL Community Server - GPL
-- SO del servidor:              Win64
-- HeidiSQL Versión:             12.8.0.6908
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Volcando estructura de base de datos para justkidsdb
CREATE DATABASE IF NOT EXISTS `justkidsdb` /*!40100 DEFAULT CHARACTER SET utf8mb3 */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `justkidsdb`;

-- Volcando estructura para tabla justkidsdb.configuracion
CREATE TABLE IF NOT EXISTS `configuracion` (
  `id` int NOT NULL AUTO_INCREMENT,
  `ConfigName` varchar(45) DEFAULT NULL,
  `ConfigDescripcion` varchar(100) DEFAULT NULL,
  `ConfigStringValue` varchar(300) DEFAULT NULL,
  `ConfigBoolValue` tinyint DEFAULT NULL,
  `ConfigIntValue` int DEFAULT NULL,
  `ConfigDecimalValue` decimal(5,2) DEFAULT NULL,
  `status` int NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb3;

-- Volcando datos para la tabla justkidsdb.configuracion: ~7 rows (aproximadamente)
INSERT INTO `configuracion` (`id`, `ConfigName`, `ConfigDescripcion`, `ConfigStringValue`, `ConfigBoolValue`, `ConfigIntValue`, `ConfigDecimalValue`, `status`) VALUES
	(1, 'PrecioMinutoTreintaMin', 'Precio de minuto de la primera media hora de 0 - 35 mins', NULL, NULL, NULL, 2.60, 1),
	(2, 'EdadMinima', 'Edad minima del niño(a)', NULL, NULL, 1, NULL, 1),
	(3, 'EdadMaxima', 'Edad maxima del niño(a)', NULL, NULL, 15, NULL, 1),
	(4, 'RutaTicket', 'Ruta del ticket', 'C:\\Casita de Molly', NULL, NULL, NULL, 1),
	(5, 'PrecioNiñoAdicional', 'Precio para niño adicional para una fiesta', NULL, NULL, NULL, 400.00, 1),
	(6, 'PrecioMinutoSesentaMin', 'Precio del minuto despues de 35 minutos', NULL, NULL, NULL, 2.21, 1),
	(7, 'PrecioMinutoDespuesServicio', 'Precio del minuto despues de que se usó un servicio', NULL, NULL, NULL, 2.10, 1);

-- Volcando estructura para tabla justkidsdb.fiestas
CREATE TABLE IF NOT EXISTS `fiestas` (
  `id` int NOT NULL AUTO_INCREMENT,
  `idServicio` int DEFAULT NULL,
  `idTurno` int DEFAULT NULL,
  `Fecha` date DEFAULT NULL,
  `Tematica` varchar(45) DEFAULT NULL,
  `EdadACumplir` int DEFAULT NULL,
  `TipoComida` varchar(45) DEFAULT NULL,
  `NinosAdicionales` int DEFAULT NULL,
  `Anticipo` decimal(8,0) DEFAULT '0',
  `Total` decimal(8,0) DEFAULT '0',
  `status` smallint DEFAULT '1',
  PRIMARY KEY (`id`),
  KEY `fk_Fiesta_Servicio_idx` (`idServicio`),
  KEY `fk_Fiesta_Turno_idx` (`idTurno`),
  CONSTRAINT `fk_Fiesta_Servicio` FOREIGN KEY (`idServicio`) REFERENCES `servicios` (`id`),
  CONSTRAINT `fk_Fiesta_Turno` FOREIGN KEY (`idTurno`) REFERENCES `turnos` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- Volcando datos para la tabla justkidsdb.fiestas: ~0 rows (aproximadamente)

-- Volcando estructura para tabla justkidsdb.fiesta_hijo
CREATE TABLE IF NOT EXISTS `fiesta_hijo` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_Fiesta` int DEFAULT NULL,
  `id_Hijo` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_Fiesta_Fiesta_idx` (`id_Fiesta`),
  KEY `fk_Fiesta_Hijo_idx` (`id_Hijo`),
  CONSTRAINT `fk_Fiesta_Fiesta` FOREIGN KEY (`id_Fiesta`) REFERENCES `fiestas` (`id`),
  CONSTRAINT `fk_Fiesta_Hijo` FOREIGN KEY (`id_Hijo`) REFERENCES `hijos` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- Volcando datos para la tabla justkidsdb.fiesta_hijo: ~0 rows (aproximadamente)

-- Volcando estructura para tabla justkidsdb.gafetes
CREATE TABLE IF NOT EXISTS `gafetes` (
  `id` int NOT NULL AUTO_INCREMENT,
  `Numero` int NOT NULL,
  `Asignado` smallint NOT NULL DEFAULT '0',
  `status` smallint NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=101 DEFAULT CHARSET=utf8mb3;

-- Volcando datos para la tabla justkidsdb.gafetes: ~100 rows (aproximadamente)
INSERT INTO `gafetes` (`id`, `Numero`, `Asignado`, `status`) VALUES
	(1, 1, 0, 1),
	(2, 2, 0, 1),
	(3, 3, 0, 1),
	(4, 4, 0, 1),
	(5, 5, 0, 1),
	(6, 6, 0, 1),
	(7, 7, 0, 1),
	(8, 8, 0, 1),
	(9, 9, 0, 1),
	(10, 10, 0, 1),
	(11, 11, 0, 1),
	(12, 12, 0, 1),
	(13, 13, 0, 1),
	(14, 14, 0, 1),
	(15, 15, 0, 1),
	(16, 16, 0, 1),
	(17, 17, 0, 1),
	(18, 18, 0, 1),
	(19, 19, 0, 1),
	(20, 20, 0, 1),
	(21, 21, 0, 1),
	(22, 22, 0, 1),
	(23, 23, 0, 1),
	(24, 24, 0, 1),
	(25, 25, 0, 1),
	(26, 26, 0, 1),
	(27, 27, 0, 1),
	(28, 28, 0, 1),
	(29, 29, 0, 1),
	(30, 30, 0, 1),
	(31, 31, 0, 1),
	(32, 32, 0, 1),
	(33, 33, 0, 1),
	(34, 34, 0, 1),
	(35, 35, 0, 1),
	(36, 36, 0, 1),
	(37, 37, 0, 1),
	(38, 38, 0, 1),
	(39, 39, 0, 1),
	(40, 40, 0, 1),
	(41, 41, 0, 1),
	(42, 42, 0, 1),
	(43, 43, 0, 1),
	(44, 44, 0, 1),
	(45, 45, 0, 1),
	(46, 46, 0, 1),
	(47, 47, 0, 1),
	(48, 48, 0, 1),
	(49, 49, 0, 1),
	(50, 50, 0, 1),
	(51, 51, 0, 1),
	(52, 52, 0, 1),
	(53, 53, 0, 1),
	(54, 54, 0, 1),
	(55, 55, 0, 1),
	(56, 56, 0, 1),
	(57, 57, 0, 1),
	(58, 58, 0, 1),
	(59, 59, 0, 1),
	(60, 60, 0, 1),
	(61, 61, 0, 1),
	(62, 62, 0, 1),
	(63, 63, 0, 1),
	(64, 64, 0, 1),
	(65, 65, 0, 1),
	(66, 66, 0, 1),
	(67, 67, 0, 1),
	(68, 68, 0, 1),
	(69, 69, 0, 1),
	(70, 70, 0, 1),
	(71, 71, 0, 1),
	(72, 72, 0, 1),
	(73, 73, 0, 1),
	(74, 74, 0, 1),
	(75, 75, 0, 1),
	(76, 76, 0, 1),
	(77, 77, 0, 1),
	(78, 78, 0, 1),
	(79, 79, 0, 1),
	(80, 80, 0, 1),
	(81, 81, 0, 1),
	(82, 82, 0, 1),
	(83, 83, 0, 1),
	(84, 84, 0, 1),
	(85, 85, 0, 1),
	(86, 86, 0, 1),
	(87, 87, 0, 1),
	(88, 88, 0, 1),
	(89, 89, 0, 1),
	(90, 90, 0, 1),
	(91, 91, 0, 1),
	(92, 92, 0, 1),
	(93, 93, 0, 1),
	(94, 94, 0, 1),
	(95, 95, 0, 1),
	(96, 96, 0, 1),
	(97, 97, 0, 1),
	(98, 98, 0, 1),
	(99, 99, 0, 1),
	(100, 100, 0, 1);

-- Volcando estructura para tabla justkidsdb.hijos
CREATE TABLE IF NOT EXISTS `hijos` (
  `id` int NOT NULL AUTO_INCREMENT,
  `NombreHijo` varchar(45) DEFAULT NULL,
  `Papa` int DEFAULT NULL,
  `Mama` int DEFAULT NULL,
  `fechaNac` varchar(45) DEFAULT NULL,
  `status` smallint DEFAULT '1',
  PRIMARY KEY (`id`),
  KEY `fk_Hijo_Papa_idx` (`Papa`),
  KEY `fk_Hijo_Mama_idx` (`Mama`),
  CONSTRAINT `fk_Hijo_Mama` FOREIGN KEY (`Mama`) REFERENCES `padres` (`id`),
  CONSTRAINT `fk_Hijo_Papa` FOREIGN KEY (`Papa`) REFERENCES `padres` (`id`) ON UPDATE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- Volcando datos para la tabla justkidsdb.hijos: ~0 rows (aproximadamente)

-- Volcando estructura para tabla justkidsdb.menu
CREATE TABLE IF NOT EXISTS `menu` (
  `id` int NOT NULL AUTO_INCREMENT,
  `MenuName` varchar(45) DEFAULT NULL,
  `ClassName` varchar(45) DEFAULT NULL,
  `MenuOrder` smallint DEFAULT NULL,
  `Path` varchar(45) DEFAULT NULL,
  `IconName` varchar(45) DEFAULT NULL,
  `status` int DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb3;

-- Volcando datos para la tabla justkidsdb.menu: ~7 rows (aproximadamente)
INSERT INTO `menu` (`id`, `MenuName`, `ClassName`, `MenuOrder`, `Path`, `IconName`, `status`) VALUES
	(1, 'Inventario', 'InventarioView', 3, 'Ludoteca.View.InventarioView', 'inventario_icon.jpg', 1),
	(2, 'Visitas', 'VisitView', 2, 'Ludoteca.View.VisitView', 'visitas_icon.jpg', 1),
	(3, 'Servicios', 'ServiciosView', 4, 'Ludoteca.View.ServiciosView', 'inventario_icon.jpg', 1),
	(4, 'Configuracion', 'ConfiguracionView', 6, 'Ludoteca.View.ConfiguracionView', 'configuracion_icon.jpg', 1),
	(5, 'Ofertas', 'OfertasView', 5, 'Ludoteca.View.OfertasView', 'inventario_icon.jpg', 1),
	(6, 'Fiestas', 'FiestasView', 2, 'Ludoteca.View.FiestasView', 'fiesta_icon.jpg', 1),
	(7, 'Reporte Visitas', 'ReporteVisitasView', 7, 'Ludoteca.View.ReporteVisitasView', 'inventario_icon.jpg', 1);

-- Volcando estructura para tabla justkidsdb.ofertas
CREATE TABLE IF NOT EXISTS `ofertas` (
  `id` int NOT NULL AUTO_INCREMENT,
  `OfertaName` varchar(45) DEFAULT NULL,
  `Descripcion` varchar(250) DEFAULT NULL,
  `Tiempo` int DEFAULT NULL,
  `totalDescuento` double DEFAULT NULL,
  `status` smallint DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- Volcando datos para la tabla justkidsdb.ofertas: ~0 rows (aproximadamente)

-- Volcando estructura para tabla justkidsdb.padres
CREATE TABLE IF NOT EXISTS `padres` (
  `id` int NOT NULL AUTO_INCREMENT,
  `PadreName` varchar(45) DEFAULT NULL,
  `Address` varchar(105) DEFAULT NULL,
  `Telefono` varchar(45) DEFAULT NULL,
  `status` smallint DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb3;

-- Volcando datos para la tabla justkidsdb.padres: ~1 rows (aproximadamente)
INSERT INTO `padres` (`id`, `PadreName`, `Address`, `Telefono`, `status`) VALUES
	(0, 'Sin Padre/Madre Asignado', '0', '0', 1);

-- Volcando estructura para tabla justkidsdb.productos
CREATE TABLE IF NOT EXISTS `productos` (
  `id` int NOT NULL AUTO_INCREMENT,
  `ProductoName` varchar(45) DEFAULT NULL,
  `Cantidad` int DEFAULT '0',
  `Precio` decimal(8,2) DEFAULT NULL,
  `status` smallint DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb3;

-- Volcando datos para la tabla justkidsdb.productos: ~1 rows (aproximadamente)
INSERT INTO `productos` (`id`, `ProductoName`, `Cantidad`, `Precio`, `status`) VALUES
	(1, 'Sin Producto', 99999999, 0.00, 1);

-- Volcando estructura para tabla justkidsdb.rol
CREATE TABLE IF NOT EXISTS `rol` (
  `id` int NOT NULL AUTO_INCREMENT,
  `RolName` varchar(45) DEFAULT NULL,
  `status` varchar(45) DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb3 COMMENT='		';

-- Volcando datos para la tabla justkidsdb.rol: ~0 rows (aproximadamente)
INSERT INTO `rol` (`id`, `RolName`, `status`) VALUES
	(1, 'Administrador', '1');

-- Volcando estructura para tabla justkidsdb.rol_menu
CREATE TABLE IF NOT EXISTS `rol_menu` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_Rol` int NOT NULL,
  `id_Menu` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_Rol_Menu_Rol_idx` (`id_Rol`),
  KEY `FK_Rol_Menu_Menu_idx` (`id_Menu`),
  CONSTRAINT `FK_Rol_Menu_Menu` FOREIGN KEY (`id_Menu`) REFERENCES `menu` (`id`),
  CONSTRAINT `FK_Rol_Menu_Rol` FOREIGN KEY (`id_Rol`) REFERENCES `rol` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb3;

-- Volcando datos para la tabla justkidsdb.rol_menu: ~7 rows (aproximadamente)
INSERT INTO `rol_menu` (`id`, `id_Rol`, `id_Menu`) VALUES
	(1, 1, 1),
	(2, 1, 2),
	(3, 1, 3),
	(4, 1, 4),
	(5, 1, 5),
	(6, 1, 6),
	(7, 1, 7);

-- Volcando estructura para tabla justkidsdb.servicios
CREATE TABLE IF NOT EXISTS `servicios` (
  `id` int NOT NULL AUTO_INCREMENT,
  `ServicioName` varchar(400) DEFAULT NULL,
  `Descripcion` text,
  `Precio` decimal(8,2) DEFAULT NULL,
  `Tiempo` int DEFAULT NULL,
  `IdTipoServicio` int DEFAULT NULL,
  `status` smallint DEFAULT '1',
  PRIMARY KEY (`id`),
  KEY `fk_Servicio_TipoServicio_idx` (`IdTipoServicio`),
  CONSTRAINT `fk_Servicio_TipoServicio` FOREIGN KEY (`IdTipoServicio`) REFERENCES `tiposervicio` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb3;

-- Volcando datos para la tabla justkidsdb.servicios: ~1 rows (aproximadamente)
INSERT INTO `servicios` (`id`, `ServicioName`, `Descripcion`, `Precio`, `Tiempo`, `IdTipoServicio`, `status`) VALUES
	(1, 'Tiempo Libre', 'Este servicio esta destinado a cobrar el minuto en base al tiempo dentro', 0.00, 0, 1, 1);

-- Volcando estructura para tabla justkidsdb.tickets
CREATE TABLE IF NOT EXISTS `tickets` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) DEFAULT NULL,
  `idvisita` int DEFAULT NULL,
  `fecha_creacion` varchar(50) DEFAULT NULL,
  `ruta` varchar(300) DEFAULT NULL,
  `status` int DEFAULT '1',
  PRIMARY KEY (`id`),
  KEY `FK_tickets_visitas` (`idvisita`),
  CONSTRAINT `FK_tickets_visitas` FOREIGN KEY (`idvisita`) REFERENCES `visitas` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- Volcando datos para la tabla justkidsdb.tickets: ~0 rows (aproximadamente)

-- Volcando estructura para tabla justkidsdb.tiposervicio
CREATE TABLE IF NOT EXISTS `tiposervicio` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) DEFAULT NULL,
  `status` smallint DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb3;

-- Volcando datos para la tabla justkidsdb.tiposervicio: ~2 rows (aproximadamente)
INSERT INTO `tiposervicio` (`id`, `nombre`, `status`) VALUES
	(1, 'Visita', 1),
	(2, 'Fiesta', 1);

-- Volcando estructura para tabla justkidsdb.turnos
CREATE TABLE IF NOT EXISTS `turnos` (
  `id` int NOT NULL AUTO_INCREMENT,
  `NombreTurno` varchar(45) DEFAULT NULL,
  `status` smallint NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb3;

-- Volcando datos para la tabla justkidsdb.turnos: ~2 rows (aproximadamente)
INSERT INTO `turnos` (`id`, `NombreTurno`, `status`) VALUES
	(1, 'Matutino', 1),
	(2, 'Vespertino', 1);

-- Volcando estructura para tabla justkidsdb.users
CREATE TABLE IF NOT EXISTS `users` (
  `id` int NOT NULL AUTO_INCREMENT,
  `UserName` varchar(45) DEFAULT NULL,
  `Password` varchar(45) DEFAULT NULL,
  `idRol` int DEFAULT NULL,
  `status` smallint DEFAULT '1',
  PRIMARY KEY (`id`),
  KEY `fk_User_Rol_idx` (`idRol`),
  CONSTRAINT `fk_User_Rol` FOREIGN KEY (`idRol`) REFERENCES `rol` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb3;

-- Volcando datos para la tabla justkidsdb.users: ~2 rows (aproximadamente)
INSERT INTO `users` (`id`, `UserName`, `Password`, `idRol`, `status`) VALUES
	(1, 'Administrator', 'JustKidAdmin', 1, 1),
	(2, 'PerlaAyala', 'Molly_2310', 1, 1);

-- Volcando estructura para tabla justkidsdb.visitas
CREATE TABLE IF NOT EXISTS `visitas` (
  `id` int NOT NULL AUTO_INCREMENT,
  `HoraEntrada` datetime NOT NULL,
  `HoraSalida` datetime DEFAULT NULL,
  `Oferta` int NOT NULL,
  `Total` decimal(8,2) NOT NULL DEFAULT '0.00',
  `GafeteId` int DEFAULT NULL,
  `NumeroGafete` int DEFAULT NULL,
  `TiempoExcedido` int DEFAULT '0',
  `TiempoTotal` int DEFAULT '0',
  `status` smallint NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`),
  KEY `fk_Visita_Oferta_idx` (`Oferta`),
  KEY `fk_Gafete_Oferta_idx` (`GafeteId`),
  CONSTRAINT `fk_Visita_Gafete` FOREIGN KEY (`GafeteId`) REFERENCES `gafetes` (`id`),
  CONSTRAINT `fk_Visita_Oferta` FOREIGN KEY (`Oferta`) REFERENCES `ofertas` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- Volcando datos para la tabla justkidsdb.visitas: ~0 rows (aproximadamente)

-- Volcando estructura para tabla justkidsdb.visita_hijo
CREATE TABLE IF NOT EXISTS `visita_hijo` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_Visita` int NOT NULL,
  `id_Hijo` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_Visita_Hijo_Visita_idx` (`id_Visita`),
  KEY `FK_Visita_Hijo_Hijo_idx` (`id_Hijo`),
  CONSTRAINT `FK_Visita_Hijo_Hijo` FOREIGN KEY (`id_Hijo`) REFERENCES `hijos` (`id`),
  CONSTRAINT `FK_Visita_Hijo_Visita` FOREIGN KEY (`id_Visita`) REFERENCES `visitas` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- Volcando datos para la tabla justkidsdb.visita_hijo: ~0 rows (aproximadamente)

-- Volcando estructura para tabla justkidsdb.visita_producto
CREATE TABLE IF NOT EXISTS `visita_producto` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_Visita` int NOT NULL,
  `id_Producto` int NOT NULL,
  `precioProductoVisita` int DEFAULT NULL,
  `CantidadProductoVisita` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_Visita_Producto_Visita_idx` (`id_Visita`),
  KEY `FK_Visita_Producto_Producto_idx` (`id_Producto`),
  CONSTRAINT `FK_Visita_Producto_Producto` FOREIGN KEY (`id_Producto`) REFERENCES `productos` (`id`),
  CONSTRAINT `FK_Visita_Producto_Visita` FOREIGN KEY (`id_Visita`) REFERENCES `visitas` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- Volcando datos para la tabla justkidsdb.visita_producto: ~0 rows (aproximadamente)

-- Volcando estructura para tabla justkidsdb.visita_servicios
CREATE TABLE IF NOT EXISTS `visita_servicios` (
  `id` int NOT NULL AUTO_INCREMENT,
  `Visita_Id` int DEFAULT NULL,
  `Servicio_Id` int DEFAULT NULL,
  `Servicio_Precio` int DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `fk_visita_Servicio_Visita_idx` (`Visita_Id`),
  KEY `fk_visita_Servicio_Servicio_idx` (`Servicio_Id`),
  CONSTRAINT `fk_visita_Servicio_Servicio` FOREIGN KEY (`Servicio_Id`) REFERENCES `servicios` (`id`),
  CONSTRAINT `fk_visita_Servicio_Visita` FOREIGN KEY (`Visita_Id`) REFERENCES `visitas` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- Volcando datos para la tabla justkidsdb.visita_servicios: ~0 rows (aproximadamente)

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;

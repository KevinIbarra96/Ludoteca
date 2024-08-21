-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versión del servidor:         8.0.29 - MySQL Community Server - GPL
-- SO del servidor:              Win64
-- HeidiSQL Versión:             12.5.0.6677
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Volcando estructura de base de datos para ludotecadb
CREATE DATABASE IF NOT EXISTS `ludotecadb` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `ludotecadb`;

-- Volcando estructura para tabla ludotecadb.configuracion
CREATE TABLE IF NOT EXISTS `configuracion` (
  `id` int NOT NULL AUTO_INCREMENT,
  `ConfigName` varchar(45) DEFAULT NULL,
  `ConfigDescripcion` varchar(100) DEFAULT NULL,
  `ConfigStringValue` varchar(45) DEFAULT NULL,
  `ConfigBoolValue` tinyint DEFAULT NULL,
  `ConfigIntValue` int DEFAULT NULL,
  `ConfigDecimalValue` decimal(5,2) DEFAULT NULL,
  `status` int NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ludotecadb.configuracion: ~1 rows (aproximadamente)
INSERT INTO `configuracion` (`id`, `ConfigName`, `ConfigDescripcion`, `ConfigStringValue`, `ConfigBoolValue`, `ConfigIntValue`, `ConfigDecimalValue`, `status`) VALUES
	(1, 'PrecioMinuto', 'Precio de cada minuto', NULL, NULL, NULL, 1.12, 1);

-- Volcando estructura para tabla ludotecadb.fiestas
CREATE TABLE IF NOT EXISTS `fiestas` (
  `id` int NOT NULL AUTO_INCREMENT,
  `FiestaName` varchar(45) DEFAULT NULL,
  `Description` varchar(100) DEFAULT NULL,
  `Precio` double DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ludotecadb.fiestas: ~0 rows (aproximadamente)

-- Volcando estructura para tabla ludotecadb.gafetes
CREATE TABLE IF NOT EXISTS `gafetes` (
  `id` int NOT NULL AUTO_INCREMENT,
  `Numero` int NOT NULL,
  `Asignado` smallint NOT NULL DEFAULT '0',
  `status` smallint NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ludotecadb.gafetes: ~21 rows (aproximadamente)
INSERT INTO `gafetes` (`id`, `Numero`, `Asignado`, `status`) VALUES
	(1, 10, 0, 1),
	(2, 11, 0, 1),
	(3, 12, 0, 1),
	(4, 13, 0, 1),
	(5, 14, 0, 1),
	(6, 15, 0, 1),
	(7, 16, 0, 1),
	(8, 17, 0, 1),
	(9, 18, 0, 1),
	(10, 19, 0, 1),
	(11, 20, 0, 1),
	(12, 21, 0, 1),
	(13, 22, 0, 1),
	(14, 23, 0, 1),
	(15, 24, 0, 1),
	(16, 25, 0, 1),
	(17, 26, 0, 1),
	(18, 27, 0, 1),
	(19, 28, 0, 1),
	(20, 29, 0, 1),
	(21, 30, 0, 1);

-- Volcando estructura para tabla ludotecadb.hijos
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
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ludotecadb.hijos: ~6 rows (aproximadamente)
INSERT INTO `hijos` (`id`, `NombreHijo`, `Papa`, `Mama`, `fechaNac`, `status`) VALUES
	(1, 'Lia Alejandra Ibarra Vazquez', 1, 2, '2024-03-08 00:10:10', 1),
	(2, 'Hector Sanchez', 3, 0, '2024-03-08 00:10:10', 1),
	(3, 'Alejandrina Ibarra Vazquez', 1, 2, '2024-03-08 00:10:10', 1),
	(28, 'Minu Federrico', 48, 0, '22/11/2013 12:00:00 a. m.', 1),
	(29, 'Mini Federrica segunda', 0, 49, '22/11/2013 12:00:00 a. m.', 1),
	(30, 'Mini Federrica tercera', 50, 51, '22/11/2013 12:00:00 a. m.', 1);

-- Volcando estructura para tabla ludotecadb.menu
CREATE TABLE IF NOT EXISTS `menu` (
  `id` int NOT NULL AUTO_INCREMENT,
  `MenuName` varchar(45) DEFAULT NULL,
  `ClassName` varchar(45) DEFAULT NULL,
  `MenuOrder` smallint DEFAULT NULL,
  `Path` varchar(45) DEFAULT NULL,
  `status` int DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ludotecadb.menu: ~6 rows (aproximadamente)
INSERT INTO `menu` (`id`, `MenuName`, `ClassName`, `MenuOrder`, `Path`, `status`) VALUES
	(1, 'Inventario', 'InventarioView', 3, 'Ludoteca.View.InventarioView', 1),
	(2, 'Visitas', 'VisitView', 2, 'Ludoteca.View.VisitView', 1),
	(3, 'Servicios', 'ServiciosView', 4, 'Ludoteca.View.ServiciosView', 1),
	(4, 'Configuracion', 'ConfiguracionView', 6, 'Ludoteca.View.ConfiguracionView', 1),
	(5, 'Ofertas', 'OfertasView', 5, 'Ludoteca.View.OfertasView', 1),
	(6, 'Fiestas', 'FiestasView', 2, 'Ludoteca.View.FiestasView', 1);

-- Volcando estructura para tabla ludotecadb.ofertas
CREATE TABLE IF NOT EXISTS `ofertas` (
  `id` int NOT NULL AUTO_INCREMENT,
  `OfertaName` varchar(45) DEFAULT NULL,
  `Descripcion` varchar(250) DEFAULT NULL,
  `Tiempo` int DEFAULT NULL,
  `totalDescuento` double DEFAULT NULL,
  `status` smallint DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ludotecadb.ofertas: ~1 rows (aproximadamente)
INSERT INTO `ofertas` (`id`, `OfertaName`, `Descripcion`, `Tiempo`, `totalDescuento`, `status`) VALUES
	(1, 'Sin Oferta', 'Opcion de oferta desiganada para no tener ofertas', 0, 0, 1);

-- Volcando estructura para tabla ludotecadb.padres
CREATE TABLE IF NOT EXISTS `padres` (
  `id` int NOT NULL AUTO_INCREMENT,
  `PadreName` varchar(45) DEFAULT NULL,
  `Address` varchar(105) DEFAULT NULL,
  `Telefono` varchar(45) DEFAULT NULL,
  `status` smallint DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=52 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ludotecadb.padres: ~8 rows (aproximadamente)
INSERT INTO `padres` (`id`, `PadreName`, `Address`, `Telefono`, `status`) VALUES
	(0, 'No padre asignado', 'NA', '0', 1),
	(1, 'Kevin Daryl Ibarra Sandoval', 'Su casa', '7531420527', 1),
	(2, 'Alejandrina Vazquez', 'Su casa', '7531679414', 1),
	(3, 'Hector Sancez Culebra', 'Su casa ', '7531454598', 1),
	(47, 'Prueba tiene que serborado', NULL, NULL, 1),
	(48, 'Federrico Diaz', 'Su casa no casa que si su casa', '7531420627', 1),
	(49, 'Doña federica', 'Su casa no casa que si su casa', '7531420628', 1),
	(50, 'Lautaro Martinez', 'Su casa no casa que si su casa', '7531420727', 1),
	(51, 'Laura Dominguez', 'Su casa no casa que si su casa', '7531420629', 1);

-- Volcando estructura para tabla ludotecadb.productos
CREATE TABLE IF NOT EXISTS `productos` (
  `id` int NOT NULL AUTO_INCREMENT,
  `ProductoName` varchar(45) DEFAULT NULL,
  `Cantidad` int DEFAULT '0',
  `Precio` int DEFAULT NULL,
  `status` smallint DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ludotecadb.productos: ~8 rows (aproximadamente)
INSERT INTO `productos` (`id`, `ProductoName`, `Cantidad`, `Precio`, `status`) VALUES
	(1, 'Calcetas chicas', 58, 10, 1),
	(2, 'Agua 200ml', 13, 20, 1),
	(3, 'Gomita Gusano pz', 11, 1, 1),
	(4, 'Slime', 21, 25, 1),
	(9, 'Spiderman Grandote', 19, 450, 1),
	(10, 'Spiderman Chiquito', 2, 150, 1),
	(15, 'Probando', 20, 23, 1),
	(16, 'Probando2', 17, 48, 1),
	(17, 'PruebaProducto', 12, 23, 1);

-- Volcando estructura para tabla ludotecadb.rol
CREATE TABLE IF NOT EXISTS `rol` (
  `id` int NOT NULL AUTO_INCREMENT,
  `RolName` varchar(45) DEFAULT NULL,
  `status` varchar(45) DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='		';

-- Volcando datos para la tabla ludotecadb.rol: ~1 rows (aproximadamente)
INSERT INTO `rol` (`id`, `RolName`, `status`) VALUES
	(1, 'Administrador', '1'),
	(2, 'Cajera', '1');

-- Volcando estructura para tabla ludotecadb.rol_menu
CREATE TABLE IF NOT EXISTS `rol_menu` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_Rol` int NOT NULL,
  `id_Menu` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_Rol_Menu_Rol_idx` (`id_Rol`),
  KEY `FK_Rol_Menu_Menu_idx` (`id_Menu`),
  CONSTRAINT `FK_Rol_Menu_Menu` FOREIGN KEY (`id_Menu`) REFERENCES `menu` (`id`),
  CONSTRAINT `FK_Rol_Menu_Rol` FOREIGN KEY (`id_Rol`) REFERENCES `rol` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ludotecadb.rol_menu: ~7 rows (aproximadamente)
INSERT INTO `rol_menu` (`id`, `id_Rol`, `id_Menu`) VALUES
	(13, 1, 1),
	(14, 1, 2),
	(15, 1, 3),
	(16, 1, 4),
	(17, 2, 2),
	(18, 1, 5),
	(19, 1, 6);

-- Volcando estructura para tabla ludotecadb.servicios
CREATE TABLE IF NOT EXISTS `servicios` (
  `id` int NOT NULL AUTO_INCREMENT,
  `ServicioName` varchar(400) DEFAULT NULL,
  `Descripcion` text,
  `Precio` int DEFAULT NULL,
  `Tiempo` int DEFAULT NULL,
  `status` smallint DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ludotecadb.servicios: ~7 rows (aproximadamente)
INSERT INTO `servicios` (`id`, `ServicioName`, `Descripcion`, `Precio`, `Tiempo`, `status`) VALUES
	(1, 'Media Hora', 'Servicio destinado con precio por minuto especial para 30 minutos', 15, 30, 1),
	(2, 'Una Hora', 'Servicio destinado a una hora con descuento ', 14, 60, 1),
	(3, 'Plan Cine', 'Para que se vallan al cine los jefes', 250, 150, 1),
	(4, 'Servicio de Prueba', 'Estoy probando los cambios que se deben percibir en cuanto se realizan las actualizaciones', 25, 56, 1),
	(5, 'fegw', 'egwweg', 212, 1212, 1),
	(6, 'Prueba pocos minutos', 'Esta solo es una prueba para probar el funcionamiento con pocos minutos.', 50, 2, 1),
	(7, 'Tiempo Libre', 'el hijo puede estar tel tiempo que sea pero se cobra a precio del minuto', 0, 0, 1);

-- Volcando estructura para tabla ludotecadb.users
CREATE TABLE IF NOT EXISTS `users` (
  `id` int NOT NULL AUTO_INCREMENT,
  `UserName` varchar(45) DEFAULT NULL,
  `Password` varchar(45) DEFAULT NULL,
  `idRol` int DEFAULT NULL,
  `status` smallint DEFAULT '1',
  PRIMARY KEY (`id`),
  KEY `fk_User_Rol_idx` (`idRol`),
  CONSTRAINT `fk_User_Rol` FOREIGN KEY (`idRol`) REFERENCES `rol` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ludotecadb.users: ~2 rows (aproximadamente)
INSERT INTO `users` (`id`, `UserName`, `Password`, `idRol`, `status`) VALUES
	(1, 'Kevin Ibarra', 'Test1', 1, 1),
	(2, 'Gerardo Valente', 'Test', 2, 1),
	(3, 'Perla Anaya', 'Prueba', 1, 1),
	(4, 'Alejandrina Vazquez', 'Prueba', 1, 1);

-- Volcando estructura para tabla ludotecadb.visitas
CREATE TABLE IF NOT EXISTS `visitas` (
  `id` int NOT NULL AUTO_INCREMENT,
  `HoraEntrada` datetime NOT NULL,
  `HoraSalida` datetime DEFAULT NULL,
  `Oferta` int NOT NULL,
  `Total` decimal(8,2) NOT NULL DEFAULT '0.00',
  `GafeteId` int DEFAULT NULL,
  `NumeroGafete` int DEFAULT NULL,
  `TiempoExcedido` int DEFAULT '0',
  `status` smallint NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`),
  KEY `fk_Visita_Oferta_idx` (`Oferta`),
  KEY `fk_Gafete_Oferta_idx` (`GafeteId`),
  CONSTRAINT `fk_Visita_Gafete` FOREIGN KEY (`GafeteId`) REFERENCES `gafetes` (`id`),
  CONSTRAINT `fk_Visita_Oferta` FOREIGN KEY (`Oferta`) REFERENCES `ofertas` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=88 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ludotecadb.visitas: ~34 rows (aproximadamente)
INSERT INTO `visitas` (`id`, `HoraEntrada`, `HoraSalida`, `Oferta`, `Total`, `GafeteId`, `NumeroGafete`, `TiempoExcedido`, `status`) VALUES
	(49, '2024-04-09 22:58:19', '2024-04-09 23:45:34', 1, 275.00, 14, 23, 0, 0),
	(50, '2024-04-09 23:03:49', '2024-04-09 23:46:07', 1, 51.00, 4, 13, 0, 0),
	(51, '2024-04-18 01:27:57', NULL, 1, 400.00, 2, 11, 0, 0),
	(52, '2024-04-18 01:28:42', NULL, 1, 29.00, 5, 14, 0, 0),
	(53, '2024-04-18 01:29:22', '2024-04-18 02:01:23', 1, 61.00, 1, 10, 0, 0),
	(54, '2024-04-18 01:32:13', NULL, 1, 175.00, 7, 16, 0, 0),
	(55, '2024-04-18 01:32:37', NULL, 1, 726.00, 6, 15, 0, 0),
	(56, '2024-04-18 01:33:08', NULL, 1, 198.00, 8, 17, 0, 0),
	(57, '2024-04-18 02:21:35', '2024-04-18 02:25:31', 1, 101.00, 4, 13, 0, 0),
	(58, '2024-04-18 02:28:10', NULL, 1, 673.00, 9, 18, 0, 0),
	(59, '2024-04-20 01:50:21', '2024-04-23 22:38:02', 1, 6235.00, 4, 13, 0, 0),
	(60, '2024-04-20 01:59:27', '2024-04-20 02:00:25', 1, 65.00, 3, 12, 0, 0),
	(61, '2024-04-23 22:59:20', '2024-04-24 00:37:41', 1, 135.00, 1, 10, 0, 0),
	(62, '2024-04-23 22:59:47', '2024-04-24 00:42:30', 1, 112.00, 10, 19, 0, 0),
	(63, '2024-04-23 23:00:34', '2024-04-24 00:43:08', 1, 110.00, 11, 20, 0, 0),
	(64, '2024-04-23 23:00:57', '2024-04-24 00:43:31', 1, 114.00, 4, 13, 0, 0),
	(65, '2024-04-23 23:01:04', '2024-04-24 00:43:56', 1, 115.00, 4, 13, 0, 0),
	(66, '2024-04-25 00:26:50', '2024-04-25 02:15:31', 1, 700.00, 3, 12, 0, 0),
	(67, '2024-05-24 13:57:41', NULL, 1, 250.00, 3, 12, 0, 0),
	(68, '2024-05-24 13:57:59', '2024-05-24 14:40:01', 1, 285.00, 3, 12, 0, 0),
	(69, '2024-06-30 16:29:04', '2024-06-30 22:22:57', 1, 657.00, 4, 13, 0, 0),
	(70, '2024-07-01 23:15:39', '2024-07-02 13:17:30', 1, 1365.00, 4, 13, 0, 0),
	(71, '2024-07-09 18:22:14', '2024-07-09 18:29:47', 1, 27.00, 3, 12, 0, 0),
	(72, '2024-07-16 01:14:20', '2024-07-18 00:38:01', 1, 3184.00, 4, 13, 0, 0),
	(73, '2024-07-16 01:18:41', '2024-07-16 01:28:17', 1, 46.00, 4, 13, 0, 0),
	(74, '2024-07-18 00:39:04', '2024-07-18 00:46:31', 1, 7.00, 3, 12, 0, 0),
	(75, '2024-07-18 00:39:34', '2024-07-18 00:46:37', 1, 17.00, 3, 12, 0, 0),
	(76, '2024-07-18 00:47:00', '2024-07-23 01:32:49', 1, 8139.00, 10, 19, 0, 0),
	(77, '2024-07-23 01:42:06', '2024-07-24 01:27:04', 1, 2088.00, 3, 12, 0, 0),
	(78, '2024-07-24 01:41:28', '2024-07-24 01:54:06', 1, 272.00, 3, 12, 0, 0),
	(79, '2024-07-24 01:56:46', '2024-07-24 01:57:21', 1, 168.00, 10, 19, 0, 0),
	(80, '2024-07-24 01:59:58', '2024-07-24 02:00:17', 1, 282.00, 4, 13, 0, 0),
	(81, '2024-07-24 02:05:38', '2024-07-24 02:16:55', 1, 507.00, 10, 19, 11, 0),
	(82, '2024-07-24 02:17:42', '2024-07-24 02:17:54', 1, 63.00, 10, 19, 0, 0),
	(83, '2024-07-24 23:56:21', '2024-07-24 23:59:16', 1, 54.00, 3, 12, 0, 0),
	(84, '2024-07-25 00:02:54', '2024-07-25 00:02:59', 1, 290.00, 1, 10, 0, 0),
	(85, '2024-07-25 00:39:55', NULL, 1, 54.00, 4, 13, 0, 0),
	(86, '2024-07-25 00:40:09', '2024-07-25 01:25:38', 1, 784.00, 4, 13, 0, 0),
	(87, '2024-08-06 01:14:08', NULL, 1, 270.00, 3, 12, 0, 1);

-- Volcando estructura para tabla ludotecadb.visita_hijo
CREATE TABLE IF NOT EXISTS `visita_hijo` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_Visita` int NOT NULL,
  `id_Hijo` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_Visita_Hijo_Visita_idx` (`id_Visita`),
  KEY `FK_Visita_Hijo_Hijo_idx` (`id_Hijo`),
  CONSTRAINT `FK_Visita_Hijo_Hijo` FOREIGN KEY (`id_Hijo`) REFERENCES `hijos` (`id`),
  CONSTRAINT `FK_Visita_Hijo_Visita` FOREIGN KEY (`id_Visita`) REFERENCES `visitas` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=83 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ludotecadb.visita_hijo: ~38 rows (aproximadamente)
INSERT INTO `visita_hijo` (`id`, `id_Visita`, `id_Hijo`) VALUES
	(41, 49, 3),
	(42, 50, 1),
	(43, 51, 3),
	(44, 51, 1),
	(45, 52, 2),
	(46, 53, 28),
	(47, 54, 29),
	(48, 55, 30),
	(49, 56, 30),
	(50, 57, 30),
	(51, 58, 1),
	(52, 59, 3),
	(53, 60, 29),
	(54, 61, 1),
	(55, 62, 29),
	(56, 63, 2),
	(57, 64, 30),
	(58, 65, 30),
	(59, 66, 1),
	(60, 67, 3),
	(61, 67, 1),
	(62, 68, 3),
	(63, 68, 1),
	(64, 69, 1),
	(65, 70, 3),
	(66, 71, 1),
	(67, 71, 3),
	(68, 72, 1),
	(69, 73, 1),
	(70, 74, 3),
	(71, 75, 3),
	(72, 76, 3),
	(73, 77, 1),
	(74, 78, 1),
	(75, 79, 3),
	(76, 80, 1),
	(77, 81, 3),
	(78, 82, 1),
	(79, 83, 1),
	(80, 84, 3),
	(81, 86, 3),
	(82, 87, 1);

-- Volcando estructura para tabla ludotecadb.visita_producto
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
) ENGINE=InnoDB AUTO_INCREMENT=151 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ludotecadb.visita_producto: ~72 rows (aproximadamente)
INSERT INTO `visita_producto` (`id`, `id_Visita`, `id_Producto`, `precioProductoVisita`, `CantidadProductoVisita`) VALUES
	(69, 49, 1, 10, 68),
	(70, 49, 2, 15, 25),
	(71, 50, 3, 1, 24),
	(72, 50, 4, 25, 37),
	(73, 51, 10, 150, 6),
	(74, 52, 2, 15, 25),
	(75, 53, 2, 15, 25),
	(76, 53, 1, 10, 68),
	(77, 53, 3, 1, 24),
	(78, 53, 4, 25, 37),
	(79, 54, 10, 150, 6),
	(80, 55, 9, 450, 9),
	(81, 55, 3, 1, 24),
	(82, 55, 2, 15, 25),
	(83, 55, 1, 10, 68),
	(84, 56, 10, 150, 6),
	(85, 56, 15, 23, 9),
	(86, 57, 1, 10, 68),
	(87, 57, 2, 15, 25),
	(88, 57, 3, 1, 24),
	(89, 57, 4, 25, 37),
	(90, 58, 9, 450, 9),
	(91, 58, 10, 150, 6),
	(92, 58, 15, 23, 9),
	(93, 60, 1, 10, 68),
	(94, 60, 2, 15, 25),
	(95, 60, 3, 1, 24),
	(96, 60, 4, 25, 37),
	(97, 61, 1, 10, 68),
	(98, 61, 2, 15, 25),
	(99, 61, 3, 1, 24),
	(100, 62, 4, 25, 37),
	(101, 63, 15, 23, 9),
	(102, 65, 3, 1, 24),
	(103, 66, 9, 450, 9),
	(104, 68, 4, 25, 37),
	(105, 68, 1, 10, 68),
	(106, 69, 2, 20, 40),
	(107, 69, 10, 150, 6),
	(108, 70, 9, 450, 9),
	(109, 71, 2, 20, 40),
	(110, 73, 1, 10, 3),
	(111, 73, 3, 1, 2),
	(112, 75, 1, 10, 1),
	(113, 76, 1, 10, 1),
	(114, 77, 2, 20, 2),
	(115, 77, 1, 10, 3),
	(116, 77, 2, 20, 1),
	(117, 77, 4, 25, 1),
	(118, 77, 10, 150, 3),
	(119, 77, 15, 23, 2),
	(120, 78, 2, 20, 1),
	(121, 78, 3, 1, 2),
	(122, 78, 4, 25, 1),
	(123, 78, 16, 48, 3),
	(124, 78, 17, 23, 2),
	(125, 78, 10, 150, 5),
	(126, 79, 2, 20, 3),
	(127, 79, 3, 1, 2),
	(128, 79, 17, 23, 4),
	(129, 80, 2, 20, 3),
	(130, 80, 4, 25, 4),
	(131, 80, 17, 23, 5),
	(132, 81, 2, 20, 1),
	(133, 81, 4, 25, 1),
	(134, 81, 9, 450, 1),
	(135, 82, 2, 20, 1),
	(136, 82, 3, 1, 3),
	(137, 82, 4, 25, 1),
	(138, 83, 2, 20, 1),
	(139, 84, 2, 20, 1),
	(140, 86, 2, 20, 1),
	(141, 86, 1, 10, 1),
	(142, 86, 2, 20, 1),
	(143, 86, 4, 25, 1),
	(144, 86, 3, 1, 1),
	(145, 86, 9, 450, 1),
	(146, 86, 10, 150, 1),
	(147, 86, 15, 23, 1),
	(148, 86, 16, 48, 1),
	(149, 86, 17, 23, 1),
	(150, 87, 1, 10, 1);

-- Volcando estructura para tabla ludotecadb.visita_servicios
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
) ENGINE=InnoDB AUTO_INCREMENT=67 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ludotecadb.visita_servicios: ~33 rows (aproximadamente)
INSERT INTO `visita_servicios` (`id`, `Visita_Id`, `Servicio_Id`, `Servicio_Precio`) VALUES
	(30, 49, 3, 250),
	(31, 50, 4, 25),
	(32, 51, 3, 250),
	(33, 52, 2, 14),
	(34, 53, 1, 7),
	(35, 54, 4, 25),
	(36, 55, 3, 250),
	(37, 56, 4, 25),
	(38, 57, 6, 50),
	(39, 58, 6, 50),
	(40, 60, 2, 14),
	(41, 61, 7, 0),
	(42, 62, 1, 7),
	(43, 63, 1, 7),
	(44, 65, 7, 0),
	(45, 66, 3, 250),
	(46, 68, 3, 250),
	(47, 69, 3, 250),
	(48, 70, 1, 7),
	(49, 71, 1, 7),
	(50, 73, 2, 14),
	(51, 75, 1, 7),
	(52, 76, 2, 14),
	(53, 77, 2, 14),
	(54, NULL, 1, 7),
	(55, 77, 1, 7),
	(56, 77, 4, 25),
	(57, 77, 7, 0),
	(58, 78, 3, 250),
	(59, 79, 2, 14),
	(60, 80, 1, 7),
	(61, 81, 7, 0),
	(62, 82, 1, 15),
	(63, 83, 2, 14),
	(64, 84, 3, 250),
	(65, 86, 2, 14),
	(66, 87, 3, 250);

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;

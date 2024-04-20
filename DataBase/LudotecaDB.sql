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
	(2, 11, 1, 1),
	(3, 12, 0, 1),
	(4, 13, 0, 1),
	(5, 14, 1, 1),
	(6, 15, 1, 1),
	(7, 16, 1, 1),
	(8, 17, 1, 1),
	(9, 18, 1, 1),
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
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ludotecadb.menu: ~4 rows (aproximadamente)
INSERT INTO `menu` (`id`, `MenuName`, `ClassName`, `MenuOrder`, `Path`, `status`) VALUES
	(1, 'Inventario', 'InventarioView', 2, 'Ludoteca.View.InventarioView', 1),
	(2, 'Visitas', 'VisitView', 1, 'Ludoteca.View.VisitView', 1),
	(3, 'Servicios', 'ServiciosView', 3, 'Ludoteca.View.ServiciosView', 1),
	(4, 'Configuracion', 'ConfiguracionView', 4, 'Ludoteca.View.ConfiguracionView', 1);

-- Volcando estructura para tabla ludotecadb.ofertas
CREATE TABLE IF NOT EXISTS `ofertas` (
  `id` int NOT NULL AUTO_INCREMENT,
  `OfertaName` varchar(45) DEFAULT NULL,
  `Descripcion` varchar(250) DEFAULT NULL,
  `Tiempo` int DEFAULT NULL,
  `status` smallint DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ludotecadb.ofertas: ~1 rows (aproximadamente)
INSERT INTO `ofertas` (`id`, `OfertaName`, `Descripcion`, `Tiempo`, `status`) VALUES
	(1, 'Sin Oferta', 'Opcion de oferta desiganada para no tener ofertas', 0, 1);

-- Volcando estructura para tabla ludotecadb.padres
CREATE TABLE IF NOT EXISTS `padres` (
  `id` int NOT NULL AUTO_INCREMENT,
  `PadreName` varchar(45) DEFAULT NULL,
  `Address` varchar(105) DEFAULT NULL,
  `Telefono` varchar(45) DEFAULT NULL,
  `status` smallint DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=52 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ludotecadb.padres: ~9 rows (aproximadamente)
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

-- Volcando datos para la tabla ludotecadb.productos: ~9 rows (aproximadamente)
INSERT INTO `productos` (`id`, `ProductoName`, `Cantidad`, `Precio`, `status`) VALUES
	(1, 'Calcetas chicas', 68, 10, 1),
	(2, 'Agua 200ml', 25, 15, 1),
	(3, 'Gomita Gusano pz', 24, 1, 1),
	(4, 'Slime', 37, 25, 1),
	(9, 'Spiderman Grandote', 9, 450, 1),
	(10, 'Spiderman Chiquito', 6, 150, 1),
	(15, 'Probando', 9, 23, 1),
	(16, 'Probando2', 6, 48, 1),
	(17, 'PruebaProducto', 0, 23, 1);

-- Volcando estructura para tabla ludotecadb.rol
CREATE TABLE IF NOT EXISTS `rol` (
  `id` int NOT NULL AUTO_INCREMENT,
  `RolName` varchar(45) DEFAULT NULL,
  `status` varchar(45) DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='		';

-- Volcando datos para la tabla ludotecadb.rol: ~2 rows (aproximadamente)
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
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ludotecadb.rol_menu: ~4 rows (aproximadamente)
INSERT INTO `rol_menu` (`id`, `id_Rol`, `id_Menu`) VALUES
	(13, 1, 1),
	(14, 1, 2),
	(15, 1, 3),
	(16, 1, 4);

-- Volcando estructura para tabla ludotecadb.servicios
CREATE TABLE IF NOT EXISTS `servicios` (
  `id` int NOT NULL AUTO_INCREMENT,
  `ServicioName` varchar(400) DEFAULT NULL,
  `Descripcion` text,
  `Precio` int DEFAULT NULL,
  `Tiempo` int DEFAULT NULL,
  `status` smallint DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ludotecadb.servicios: ~6 rows (aproximadamente)
INSERT INTO `servicios` (`id`, `ServicioName`, `Descripcion`, `Precio`, `Tiempo`, `status`) VALUES
	(1, 'Media Hora', 'Servicio destinado con precio por minuto especial para 30 minutos', 7, 30, 1),
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

-- Volcando datos para la tabla ludotecadb.users: ~4 rows (aproximadamente)
INSERT INTO `users` (`id`, `UserName`, `Password`, `idRol`, `status`) VALUES
	(1, 'Kevin Ibarra', 'Test1', 1, 1),
	(2, 'Gerardo Valente', 'Test', 1, 1),
	(3, 'Perla Anaya', 'Prueba', 1, 1),
	(4, 'Alejandrina Vazquez', 'Prueba', 1, 1);

-- Volcando estructura para tabla ludotecadb.visitas
CREATE TABLE IF NOT EXISTS `visitas` (
  `id` int NOT NULL AUTO_INCREMENT,
  `HoraEntrada` datetime NOT NULL,
  `HoraSalida` datetime DEFAULT NULL,
  `Oferta` int NOT NULL,
  `Total` int NOT NULL DEFAULT '0',
  `GafeteId` int DEFAULT NULL,
  `NumeroGafete` int DEFAULT NULL,
  `status` smallint NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`),
  KEY `fk_Visita_Oferta_idx` (`Oferta`),
  KEY `fk_Gafete_Oferta_idx` (`GafeteId`),
  CONSTRAINT `fk_Visita_Gafete` FOREIGN KEY (`GafeteId`) REFERENCES `gafetes` (`id`),
  CONSTRAINT `fk_Visita_Oferta` FOREIGN KEY (`Oferta`) REFERENCES `ofertas` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=59 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ludotecadb.visitas: ~10 rows (aproximadamente)
INSERT INTO `visitas` (`id`, `HoraEntrada`, `HoraSalida`, `Oferta`, `Total`, `GafeteId`, `NumeroGafete`, `status`) VALUES
	(49, '2024-04-09 22:58:19', '2024-04-09 23:45:34', 1, 275, 14, 23, 0),
	(50, '2024-04-09 23:03:49', '2024-04-09 23:46:07', 1, 51, 4, 13, 0),
	(51, '2024-04-18 01:27:57', NULL, 1, 400, 2, 11, 0),
	(52, '2024-04-18 01:28:42', NULL, 1, 29, 5, 14, 0),
	(53, '2024-04-18 01:29:22', '2024-04-18 02:01:23', 1, 61, 1, 10, 0),
	(54, '2024-04-18 01:32:13', NULL, 1, 175, 7, 16, 0),
	(55, '2024-04-18 01:32:37', NULL, 1, 726, 6, 15, 0),
	(56, '2024-04-18 01:33:08', NULL, 1, 198, 8, 17, 0),
	(57, '2024-04-18 02:21:35', '2024-04-18 02:25:31', 1, 101, 4, 13, 0),
	(58, '2024-04-18 02:28:10', NULL, 1, 673, 9, 18, 0),
	(59, '2024-04-20 01:50:21', NULL, 1, 7, 4, 13, 1);

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
) ENGINE=InnoDB AUTO_INCREMENT=52 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ludotecadb.visita_hijo: ~11 rows (aproximadamente)
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
	(52, 59, 3);

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
) ENGINE=InnoDB AUTO_INCREMENT=93 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ludotecadb.visita_producto: ~24 rows (aproximadamente)
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
	(92, 58, 15, 23, 9);

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
) ENGINE=InnoDB AUTO_INCREMENT=40 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ludotecadb.visita_servicios: ~10 rows (aproximadamente)
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
	(39, 58, 6, 50);

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;

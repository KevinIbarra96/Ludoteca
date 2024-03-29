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
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ludotecadb.hijos: ~2 rows (aproximadamente)
INSERT INTO `hijos` (`id`, `NombreHijo`, `Papa`, `Mama`, `fechaNac`, `status`) VALUES
	(1, 'Lia Alejandra Ibarra Vazquez', 1, 2, '2024-03-08 00:10:10', 1),
	(2, 'Hector Sanchez', 3, NULL, '2024-03-08 00:10:10', 1),
	(3, 'Alejandrina Ibarra Vazquez', 1, 2, '2024-03-08 00:10:10', 1);

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

-- Volcando datos para la tabla ludotecadb.ofertas: ~0 rows (aproximadamente)
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
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ludotecadb.padres: ~2 rows (aproximadamente)
INSERT INTO `padres` (`id`, `PadreName`, `Address`, `Telefono`, `status`) VALUES
	(1, 'Kevin Daryl Ibarra Sandoval', 'Su casa', '7531420527', 1),
	(2, 'Alejandrina Vazquez', 'Su casa', '7531679414', 1),
	(3, 'Hector Sancez Culebra', 'Su casa ', '7531454598', 1);

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
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ludotecadb.servicios: ~5 rows (aproximadamente)
INSERT INTO `servicios` (`id`, `ServicioName`, `Descripcion`, `Precio`, `Tiempo`, `status`) VALUES
	(1, 'Media Hora', 'Servicio destinado con precio por minuto especial para 30 minutos', 7, 30, 1),
	(2, 'Una Hora', 'Servicio destinado a una hora con descuento ', 14, 60, 1),
	(3, 'Plan Cine', 'Para que se vallan al cine los jefes', 250, 150, 1),
	(4, 'Servicio de Prueba', 'Estoy probando los cambios que se deben percibir en cuanto se realizan las actualizaciones', 25, 56, 1),
	(5, 'fegw', 'egwweg', 212, 1212, 1);

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
  `status` smallint NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`),
  KEY `fk_Visita_Oferta_idx` (`Oferta`),
  CONSTRAINT `fk_Visita_Oferta` FOREIGN KEY (`Oferta`) REFERENCES `ofertas` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=34 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ludotecadb.visitas: ~13 rows (aproximadamente)
INSERT INTO `visitas` (`id`, `HoraEntrada`, `HoraSalida`, `Oferta`, `Total`, `status`) VALUES
	(1, '2024-03-23 03:13:49', '2024-03-15 00:00:00', 1, 0, 0),
	(2, '2024-03-23 03:13:49', '2024-03-15 00:00:00', 1, 0, 1),
	(23, '2024-03-26 22:46:37', NULL, 1, 700, 1),
	(24, '2024-03-26 22:55:24', NULL, 1, 501, 1),
	(25, '2024-03-26 23:06:37', NULL, 1, 476, 1),
	(26, '2024-03-26 23:30:38', NULL, 1, 276, 1),
	(27, '2024-03-26 23:40:48', NULL, 1, 235, 1),
	(28, '2024-03-26 23:43:53', NULL, 1, 946, 1),
	(29, '2024-03-26 23:46:34', NULL, 1, 291, 1),
	(30, '2024-03-26 23:53:13', NULL, 1, 751, 1),
	(31, '2024-03-29 12:27:53', NULL, 1, 898, 1),
	(32, '2024-03-29 12:36:45', NULL, 1, 700, 1),
	(33, '2024-03-29 12:44:57', NULL, 1, 725, 1);

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
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ludotecadb.visita_hijo: ~19 rows (aproximadamente)
INSERT INTO `visita_hijo` (`id`, `id_Visita`, `id_Hijo`) VALUES
	(1, 1, 1),
	(2, 2, 2),
	(3, 1, 3),
	(4, 1, 1),
	(5, 1, 1),
	(10, 23, 1),
	(11, 24, 1),
	(12, 25, 1),
	(13, 25, 3),
	(14, 26, 3),
	(15, 27, 1),
	(16, 28, 3),
	(17, 28, 1),
	(18, 29, 1),
	(19, 29, 3),
	(20, 30, 3),
	(21, 31, 3),
	(22, 32, 1),
	(23, 33, 1);

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
) ENGINE=InnoDB AUTO_INCREMENT=37 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ludotecadb.visita_producto: ~36 rows (aproximadamente)
INSERT INTO `visita_producto` (`id`, `id_Visita`, `id_Producto`, `precioProductoVisita`, `CantidadProductoVisita`) VALUES
	(1, 1, 1, 68, 1),
	(2, 1, 2, 15, 2),
	(3, 1, 3, 1, 5),
	(4, 1, 4, 25, 3),
	(5, 1, 9, 450, 9),
	(6, 1, 9, 450, 9),
	(7, 23, 9, 450, 9),
	(8, 24, 9, 450, 9),
	(9, 25, 9, 450, 9),
	(10, 25, 3, 1, 24),
	(11, 26, 3, 1, 24),
	(12, 26, 2, 15, 25),
	(13, 26, 1, 10, 68),
	(14, 27, 16, 48, 6),
	(15, 27, 15, 23, 9),
	(16, 27, 10, 150, 6),
	(17, 28, 16, 48, 6),
	(18, 28, 15, 23, 9),
	(19, 28, 10, 150, 6),
	(20, 28, 9, 450, 9),
	(21, 28, 4, 25, 37),
	(22, 29, 4, 25, 37),
	(23, 29, 3, 1, 24),
	(24, 29, 2, 15, 25),
	(25, 30, 9, 450, 9),
	(26, 30, 4, 25, 37),
	(27, 30, 3, 1, 24),
	(28, 30, 2, 15, 25),
	(29, 30, 1, 10, 68),
	(30, 31, 9, 450, 9),
	(31, 31, 10, 150, 6),
	(32, 31, 15, 23, 9),
	(33, 31, 4, 25, 37),
	(34, 32, 9, 450, 9),
	(35, 33, 9, 450, 9),
	(36, 33, 4, 25, 37);

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
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ludotecadb.visita_servicios: ~15 rows (aproximadamente)
INSERT INTO `visita_servicios` (`id`, `Visita_Id`, `Servicio_Id`, `Servicio_Precio`) VALUES
	(1, 1, 1, 7),
	(2, 2, 1, 7),
	(3, 1, 3, 250),
	(4, 1, 3, 250),
	(5, 23, 3, 250),
	(6, 24, 4, 25),
	(7, 25, 4, 25),
	(8, 26, 3, 250),
	(9, 27, 2, 14),
	(10, 28, 3, 250),
	(11, 29, 3, 250),
	(12, 30, 3, 250),
	(13, 31, 3, 250),
	(14, 32, 3, 250),
	(15, 33, 3, 250);

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;

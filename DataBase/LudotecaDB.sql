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
  `fechaNac` date DEFAULT NULL,
  `status` smallint DEFAULT '1',
  PRIMARY KEY (`id`),
  KEY `fk_Hijo_Papa_idx` (`Papa`),
  KEY `fk_Hijo_Mama_idx` (`Mama`),
  CONSTRAINT `fk_Hijo_Mama` FOREIGN KEY (`Mama`) REFERENCES `padres` (`id`),
  CONSTRAINT `fk_Hijo_Papa` FOREIGN KEY (`Papa`) REFERENCES `padres` (`id`) ON UPDATE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ludotecadb.hijos: ~0 rows (aproximadamente)

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
  `Descripcion` varchar(45) DEFAULT NULL,
  `Tiempo` int DEFAULT NULL,
  `status` smallint DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ludotecadb.ofertas: ~0 rows (aproximadamente)

-- Volcando estructura para tabla ludotecadb.padres
CREATE TABLE IF NOT EXISTS `padres` (
  `id` int NOT NULL AUTO_INCREMENT,
  `PadreName` varchar(45) DEFAULT NULL,
  `Address` varchar(105) DEFAULT NULL,
  `Telefono` varchar(45) DEFAULT NULL,
  `status` smallint DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ludotecadb.padres: ~0 rows (aproximadamente)

-- Volcando estructura para tabla ludotecadb.productos
CREATE TABLE IF NOT EXISTS `productos` (
  `id` int NOT NULL AUTO_INCREMENT,
  `ProductoName` varchar(45) DEFAULT NULL,
  `Cantidad` int DEFAULT '0',
  `Precio` varchar(45) DEFAULT NULL,
  `status` smallint DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ludotecadb.productos: ~8 rows (aproximadamente)
INSERT INTO `productos` (`id`, `ProductoName`, `Cantidad`, `Precio`, `status`) VALUES
	(1, 'Calcetas chicas', 68, '10', 1),
	(2, 'Agua 200ml', 25, '15', 1),
	(3, 'Gomita Gusano pz', 24, '1', 1),
	(4, 'Slime', 37, '25', 1),
	(9, 'Spiderman Grandote', 9, '450', 1),
	(10, 'Spiderman Chiquito', 6, '150', 1),
	(15, 'Probando', 9, '23', 1),
	(16, 'Probando2', 6, '48', 1);

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
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ludotecadb.servicios: ~5 rows (aproximadamente)
INSERT INTO `servicios` (`id`, `ServicioName`, `Descripcion`, `Precio`, `Tiempo`, `status`) VALUES
	(1, 'Media Hora', 'Servicio destinado con precio por minuto especial para 30 minutos', 4, 30, 1),
	(2, 'Una Hora', 'Servicio destinado a una hora con descuento ', 14, 60, 1),
	(3, 'Plan Cine', 'Para que se vallan al cine los jefes', 145, 150, 1),
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
  `Servicio` int NOT NULL,
  `HoraEntrada` time NOT NULL,
  `HoraSalida` time NOT NULL,
  `Oferta` int NOT NULL,
  `status` smallint DEFAULT '1',
  PRIMARY KEY (`id`),
  KEY `fk_Visita_Oferta_idx` (`Oferta`),
  KEY `FK_Visita_Servicio_idx` (`Servicio`),
  CONSTRAINT `fk_Visita_Oferta` FOREIGN KEY (`Oferta`) REFERENCES `ofertas` (`id`),
  CONSTRAINT `FK_Visita_Servicio` FOREIGN KEY (`Servicio`) REFERENCES `servicios` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ludotecadb.visitas: ~0 rows (aproximadamente)

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ludotecadb.visita_hijo: ~0 rows (aproximadamente)

-- Volcando estructura para tabla ludotecadb.visita_producto
CREATE TABLE IF NOT EXISTS `visita_producto` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_Visita` int NOT NULL,
  `id_Producto` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_Visita_Producto_Visita_idx` (`id_Visita`),
  KEY `FK_Visita_Producto_Producto_idx` (`id_Producto`),
  CONSTRAINT `FK_Visita_Producto_Producto` FOREIGN KEY (`id_Producto`) REFERENCES `productos` (`id`),
  CONSTRAINT `FK_Visita_Producto_Visita` FOREIGN KEY (`id_Visita`) REFERENCES `visitas` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ludotecadb.visita_producto: ~0 rows (aproximadamente)

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;

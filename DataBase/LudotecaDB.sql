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
  `Rol` int DEFAULT NULL,
  `ClassName` varchar(45) DEFAULT NULL,
  `MenuOrder` smallint DEFAULT NULL,
  `Path` varchar(45) DEFAULT NULL,
  `status` int DEFAULT '1',
  PRIMARY KEY (`id`),
  KEY `fk_Menu_Rol_idx` (`Rol`),
  CONSTRAINT `fk_Menu_Rol` FOREIGN KEY (`Rol`) REFERENCES `rol` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ludotecadb.menu: ~4 rows (aproximadamente)
INSERT INTO `menu` (`id`, `MenuName`, `Rol`, `ClassName`, `MenuOrder`, `Path`, `status`) VALUES
	(1, 'Inventario', 1, 'InventarioView', 2, 'Ludoteca.View.InventarioView', 1),
	(2, 'Visitas', 1, 'VisitView', 1, 'Ludoteca.View.VisitView', 1),
	(3, 'Servicios', 1, 'ServiciosView', 3, 'Ludoteca.View.ServiciosView', 1),
	(4, 'Configuracion', 1, 'ConfiguracionView', 4, 'Ludoteca.View.ConfiguracionView', 1);

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
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ludotecadb.productos: ~6 rows (aproximadamente)
INSERT INTO `productos` (`id`, `ProductoName`, `Cantidad`, `Precio`, `status`) VALUES
	(1, 'Calcetas ch', 64, '10', 1),
	(2, 'Agua 500ml', 20, '12', 1),
	(3, 'Gomita Gusano pz', 16, '3', 1),
	(4, 'Slime', 30, '20', 1),
	(9, 'Spiderman Grandote', 0, '450', 1),
	(10, 'Spiderman Chiquit', 0, '152', 1);

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

-- Volcando estructura para tabla ludotecadb.servicios
CREATE TABLE IF NOT EXISTS `servicios` (
  `id` int NOT NULL AUTO_INCREMENT,
  `ServicioName` varchar(45) DEFAULT NULL,
  `Tiempo` int DEFAULT NULL,
  `status` varchar(45) DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ludotecadb.servicios: ~0 rows (aproximadamente)

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
  `Hijo` int NOT NULL,
  `Servicio` int NOT NULL,
  `Productos` varchar(45) NOT NULL,
  `HoraEntrada` time NOT NULL,
  `HoraSalida` time NOT NULL,
  `Oferta` int DEFAULT NULL,
  `status` smallint DEFAULT '1',
  PRIMARY KEY (`id`),
  KEY `fk_Visita_Hijo_idx` (`Hijo`),
  KEY `fk_Visita_Servicio_idx` (`Servicio`),
  KEY `fk_Visita_Oferta_idx` (`Oferta`),
  CONSTRAINT `fk_Visita_Hijo` FOREIGN KEY (`Hijo`) REFERENCES `hijos` (`id`),
  CONSTRAINT `fk_Visita_Oferta` FOREIGN KEY (`Oferta`) REFERENCES `ofertas` (`id`),
  CONSTRAINT `fk_Visita_Servicio` FOREIGN KEY (`Servicio`) REFERENCES `servicios` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla ludotecadb.visitas: ~0 rows (aproximadamente)

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;

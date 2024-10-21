-- MySQL dump 10.13  Distrib 8.0.38, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: apptvcakoi
-- ------------------------------------------------------
-- Server version	9.0.1

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `product`
--

DROP TABLE IF EXISTS `product`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `product` (
  `idproduct` int NOT NULL AUTO_INCREMENT,
  `name_product` text COLLATE utf8mb3_bin NOT NULL,
  `description` text COLLATE utf8mb3_bin,
  `username` varchar(45) COLLATE utf8mb3_bin NOT NULL,
  `color_product` varchar(45) COLLATE utf8mb3_bin DEFAULT NULL,
  `destiny_product` varchar(45) COLLATE utf8mb3_bin DEFAULT NULL,
  `img_product` varchar(45) COLLATE utf8mb3_bin DEFAULT NULL,
  `idproduct_type` int DEFAULT NULL,
  PRIMARY KEY (`idproduct`),
  KEY `FK_Idproducttype` (`idproduct_type`),
  KEY `FK_Username` (`username`),
  CONSTRAINT `FK_Idproducttype` FOREIGN KEY (`idproduct_type`) REFERENCES `product_type` (`idproduct_type`),
  CONSTRAINT `FK_Username` FOREIGN KEY (`username`) REFERENCES `ql_user` (`username`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product`
--

LOCK TABLES `product` WRITE;
/*!40000 ALTER TABLE `product` DISABLE KEYS */;
INSERT INTO `product` VALUES (1,'Hồ cá koi mini đẹp ','Với nhiều căn nhà có diện tích khuôn viên hạn chế, gia chủ thường cân nhắc tận dụng diện tích trong nhà để thiết kế hồ cá koi mini. ','tandat2882',NULL,NULL,NULL,1),(2,'Hồ cá koi đơn giản chuẩn phong thủy','Mẫu thiết kế hồ cá koi đơn giản thường được đặt ở hiên trước nhà vì đây là vị trí đắc địa: vừa đáp ứng các yếu tố thẩm mỹ, vừa tạo thế “tiền thủy” mang tài lộc, vận may đến gia đình chủ nhà.','duymanh283',NULL,NULL,NULL,1),(3,'Hồ cá koi biệt thự đẹp','Xu hướng thi công hồ cá koi trong sân vườn biệt thự cao cấp hiện đang được nhiều người ưa chuộng. Chỉ cần ngồi trong phòng khách ngắm nhìn đàn cá bơi lội, gia chủ cũng cảm nhận được sự bình yên và an tĩnh.','thienkim2881',NULL,NULL,NULL,1),(4,'Hikari Hi Utsuri',NULL,'tandat2882','Đen, Đỏ','Thổ, Mộc',NULL,2),(5,'Ki Utsuri',NULL,'tandat2882','Đen, Vàng','Kim, Thủy',NULL,2),(6,'Hikari Kin Showa',NULL,'tandat2882','Đen, Đỏ, Trắng','Kim, Mộc, Thổ, Thủy',NULL,2),(7,'Shiro Utsuri',NULL,'tandat2882','Đen, Trắng','Kim, Mộc, Thổ, Thủy',NULL,2),(8,'Tancho Kohaku',NULL,'tandat2882','Trắng, Đỏ','Kim, Hỏa',NULL,2),(9,'Tancho – Sanke',NULL,'tandat2882','Trắng, Đỏ, Đen','Kim, Hỏa, Mộc, Thổ, Thủy',NULL,2),(10,'Koi Tancho – Showa',NULL,'tandat2882','Trắng, Đỏ, Đen','Kim, Hỏa, Mộc, Thổ, Thủy',NULL,2),(11,'Mameshibori Goshiki',NULL,'tandat2882','Đỏ, Trắng, Xanh','Kim, Hỏa, Thủy',NULL,2),(12,'KinDai Goshiki',NULL,'tandat2882','Trắng, Đen, Đỏ','Kim, Hỏa, Mộc, Thổ, Thủy',NULL,2),(13,'Kuro Goshiki',NULL,'tandat2882','Đen, Đỏ','Hỏa, Mộc, Thổ, Thủy',NULL,2),(14,'Nezu Goshiki',NULL,'tandat2882','Đỏ, Trắng','Hỏa, Kim',NULL,2),(15,'Ginrin Goshiki',NULL,'tandat2882','Đen, Đỏ','Hỏa, Mộc, Thổ, Thủy',NULL,2);
/*!40000 ALTER TABLE `product` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product_type`
--

DROP TABLE IF EXISTS `product_type`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `product_type` (
  `idproduct_type` int NOT NULL AUTO_INCREMENT,
  `name_type` varchar(45) NOT NULL,
  PRIMARY KEY (`name_type`),
  UNIQUE KEY `name_type_UNIQUE` (`name_type`),
  UNIQUE KEY `idproduct_type_UNIQUE` (`idproduct_type`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product_type`
--

LOCK TABLES `product_type` WRITE;
/*!40000 ALTER TABLE `product_type` DISABLE KEYS */;
INSERT INTO `product_type` VALUES (1,'Hồ cá'),(2,'Cá koi'),(3,'Sản phẩm chăm sóc cá'),(4,'Sản phẩm trang trí'),(5,'Thiết bị'),(6,'Phụ kiện');
/*!40000 ALTER TABLE `product_type` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product_user`
--

DROP TABLE IF EXISTS `product_user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `product_user` (
  `idproduct_user` int NOT NULL AUTO_INCREMENT,
  `name_product` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `description` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `username` varchar(45) CHARACTER SET utf8mb3 COLLATE utf8mb3_bin NOT NULL,
  `color_product` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `destiny_product` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `img_product` varchar(45) COLLATE utf8mb3_bin DEFAULT NULL,
  `idproduct_type` int DEFAULT NULL,
  PRIMARY KEY (`idproduct_user`),
  KEY `FK_Idproduct_User` (`idproduct_type`),
  KEY `FK_Username_User` (`username`),
  CONSTRAINT `FK_Idproduct_User` FOREIGN KEY (`idproduct_type`) REFERENCES `product_type` (`idproduct_type`),
  CONSTRAINT `FK_Username_User` FOREIGN KEY (`username`) REFERENCES `ql_user` (`username`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product_user`
--

LOCK TABLES `product_user` WRITE;
/*!40000 ALTER TABLE `product_user` DISABLE KEYS */;
INSERT INTO `product_user` VALUES (1,'Hồ cá koi ngoài trời','Nhờ được thiết kế tròn trịa, nhẹ nhàng và tinh tế, công trình thiết kế hồ cá koi ngoài trời như một tuyệt tác giữa khuôn viên nhà, trở thành điểm nhấn thu hút mọi ánh nhìn của khách ghé chơi.','vuanhne992',NULL,NULL,NULL,1);
/*!40000 ALTER TABLE `product_user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ql_parameter`
--

DROP TABLE IF EXISTS `ql_parameter`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ql_parameter` (
  `idql_parameter` int NOT NULL AUTO_INCREMENT,
  `name_destiny` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `number_fish` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `direction` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`idql_parameter`,`name_destiny`),
  UNIQUE KEY `name_destiny_UNIQUE` (`name_destiny`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ql_parameter`
--

LOCK TABLES `ql_parameter` WRITE;
/*!40000 ALTER TABLE `ql_parameter` DISABLE KEYS */;
INSERT INTO `ql_parameter` VALUES (1,'Mộc','3 hoặc 9','Đông Nam'),(2,'Thủy','1 hoặc 6','Bắc'),(3,'Hỏa','2 hoặc 7','Bắc'),(4,'Thổ','5 hoặc 10','Đông Bắc hoặc Tây Nam'),(5,'Kim','4 hoặc 9','Tây hoặc Tây Nam');
/*!40000 ALTER TABLE `ql_parameter` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ql_user`
--

DROP TABLE IF EXISTS `ql_user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ql_user` (
  `id_user` int NOT NULL AUTO_INCREMENT,
  `name_user` varchar(45) COLLATE utf8mb3_bin NOT NULL,
  `username` varchar(45) COLLATE utf8mb3_bin NOT NULL,
  `pass_user` varchar(45) COLLATE utf8mb3_bin NOT NULL,
  `phone` varchar(45) COLLATE utf8mb3_bin DEFAULT NULL,
  `email` varchar(45) COLLATE utf8mb3_bin DEFAULT NULL,
  `facebook` text COLLATE utf8mb3_bin,
  `access_user` varchar(10) CHARACTER SET utf8mb3 COLLATE utf8mb3_bin DEFAULT 'user',
  PRIMARY KEY (`id_user`,`username`),
  UNIQUE KEY `username_UNIQUE` (`username`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ql_user`
--

LOCK TABLES `ql_user` WRITE;
/*!40000 ALTER TABLE `ql_user` DISABLE KEYS */;
INSERT INTO `ql_user` VALUES (1,'Huỳnh Tấn Đạt','tandat2882','dat123@@',NULL,NULL,NULL,'user'),(2,'Đỗ Duy Mạnh','duymanh283','manh992@#@',NULL,NULL,NULL,'user'),(3,'Thiên Vũ Kim','thienkim2881','kimvu00233@',NULL,NULL,NULL,'user'),(4,'Hoàng Vũ Anh','vuanhne992','thanhnam28882',NULL,NULL,NULL,'user'),(5,'Huỳnh Mai Nhật Minh','minh28052005','minh28052005@@',NULL,NULL,NULL,'admin');
/*!40000 ALTER TABLE `ql_user` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-10-21 21:04:14

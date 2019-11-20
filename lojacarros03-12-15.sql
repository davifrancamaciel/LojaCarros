-- --------------------------------------------------------
-- Servidor:                     127.0.0.1
-- Versão do servidor:           5.0.45-community-nt - MySQL Community Edition (GPL)
-- OS do Servidor:               Win32
-- HeidiSQL Versão:              9.1.0.4867
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

-- Copiando estrutura do banco de dados para lojacarros
CREATE DATABASE IF NOT EXISTS `lojacarros` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `lojacarros`;


-- Copiando estrutura para tabela lojacarros.arquivo
CREATE TABLE IF NOT EXISTS `arquivo` (
  `IdArquivo` int(11) NOT NULL auto_increment,
  `Nome` varchar(100) NOT NULL,
  `NomeAnterior` varchar(100) NOT NULL,
  `Tamanho` varchar(10) NOT NULL,
  `DataCadastro` datetime NOT NULL,
  `IdVeiculo` int(11) default NULL,
  PRIMARY KEY  (`IdArquivo`),
  KEY `IdVeiculo` (`IdVeiculo`),
  CONSTRAINT `IdVeiculo` FOREIGN KEY (`IdVeiculo`) REFERENCES `veiculo` (`IdVeiculo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=295 DEFAULT CHARSET=latin1;

-- Copiando dados para a tabela lojacarros.arquivo: ~99 rows (aproximadamente)
/*!40000 ALTER TABLE `arquivo` DISABLE KEYS */;
INSERT INTO `arquivo` (`IdArquivo`, `Nome`, `NomeAnterior`, `Tamanho`, `DataCadastro`, `IdVeiculo`) VALUES
	(192, 'a9cfea03-7bf1-4539-aab5-7722d601a5c8.jpg', 'IMG_20151114_124600775.jpg', '1368543', '2015-11-16 12:15:22', 90),
	(193, 'bfb0fc10-93b8-4850-9e0e-1eeb52e83005.jpg', 'IMG_20151114_124612153.jpg', '1162980', '2015-11-16 12:15:30', 90),
	(194, '14a4a49c-2a31-4660-809a-4a9bb6df7145.jpg', 'IMG_20151114_124622778.jpg', '1260561', '2015-11-16 12:15:38', 90),
	(195, 'a220539f-0852-4fbc-8a9c-c4587ceaa35a.jpg', 'IMG_20151114_124716762.jpg', '1271585', '2015-11-16 12:17:43', 91),
	(196, '475eebba-9043-4b9f-80b3-a3e977114924.jpg', 'IMG_20151114_124637320.jpg', '1389256', '2015-11-16 12:18:20', 91),
	(197, '0f2bcbae-619f-4668-a211-b62da6506ac8.jpg', 'IMG_20151114_124657927.jpg', '1281769', '2015-11-16 12:18:27', 91),
	(198, 'ffd915de-0e69-4996-a982-5f18a4c91655.jpg', 'IMG_20151114_124734182.jpg', '1040516', '2015-11-16 12:18:34', 91),
	(199, '33818952-d665-46bc-a025-66f02808711f.jpg', 'IMG_20151114_124443335.jpg', '1412285', '2015-11-16 13:23:10', 92),
	(200, 'a3b7cd8e-c8e9-41fb-90b6-8a2613a1aa9c.jpg', 'IMG_20151114_124506167.jpg', '1184590', '2015-11-16 13:23:44', 92),
	(201, 'f961e218-3cf7-4f8b-9e00-d4dd475ab0b2.jpg', 'IMG_20151114_124516239.jpg', '1131497', '2015-11-16 13:23:51', 92),
	(202, '969a3d43-0c35-495c-85d3-f5451a017931.jpg', 'IMG_20151114_124527881.jpg', '1330005', '2015-11-16 13:23:59', 92),
	(203, 'a872fc8f-cc29-4fd6-a62a-9f65a3fff0f8.jpg', 'IMG_20151114_124802222.jpg', '1266082', '2015-11-16 13:24:42', 93),
	(204, 'b2aeaaf8-bcd9-4c27-8018-21d1c9526d15.jpg', 'IMG_20151114_124816207.jpg', '1337152', '2015-11-16 13:24:50', 93),
	(205, 'e696bf6e-4e72-4c8e-b132-ae234db658f0.jpg', 'IMG_20151114_124857378.jpg', '1257837', '2015-11-16 13:24:57', 93),
	(206, '8ff707e8-d6c7-4b68-a1ce-7f75300dab2c.jpg', 'IMG_20151114_124911458.jpg', '1149449', '2015-11-16 13:28:25', 94),
	(207, '08c64d9e-9937-4c50-95e1-e73785a5a35e.jpg', 'IMG_20151114_124941098.jpg', '1375379', '2015-11-16 13:28:33', 94),
	(208, '4ece3964-6640-424b-a3d3-b861cb683065.jpg', 'IMG_20151114_124953395.jpg', '1279498', '2015-11-16 13:28:40', 94),
	(209, 'ac75b5f9-0a1b-4a69-9736-be701a954dd4.jpg', 'IMG_20151114_125008220.jpg', '1239057', '2015-11-16 13:28:48', 94),
	(210, '33358765-483f-4a1b-a75c-334b7969f7ac.jpg', 'IMG_20151114_125826074.jpg', '1382966', '2015-11-16 14:02:24', 95),
	(211, '4a76f970-5af2-42f6-b9b8-1fd2f62c8fca.jpg', 'IMG_20151114_125837671.jpg', '1294166', '2015-11-16 14:02:52', 95),
	(212, '27380483-e702-4ae3-88af-e173deeb1ee2.jpg', 'IMG_20151114_125903485.jpg', '1099547', '2015-11-16 14:02:59', 95),
	(213, 'ad19a2c7-f772-46e4-bf5d-046e906bb03d.jpg', 'IMG_20151114_130029677.jpg', '1187318', '2015-11-16 14:03:06', 95),
	(214, '37e932d5-3b9a-4166-b218-adab98fcc2a9.jpg', 'IMG_20151114_130040487.jpg', '1114909', '2015-11-16 14:03:14', 95),
	(215, '582bd9d1-79d4-427a-b6e5-af19318b5c88.jpg', 'IMG_20151114_130319509.jpg', '1170191', '2015-11-16 14:03:58', 96),
	(216, '0f1ea03f-0292-4ea7-b643-f210b0239c1c.jpg', 'IMG_20151114_130329427.jpg', '1197528', '2015-11-16 14:04:55', 96),
	(217, 'a4485bff-0a33-44c2-b955-8310a60f7aa8.jpg', 'IMG_20151114_130422181.jpg', '1227823', '2015-11-16 14:05:02', 96),
	(218, '428e7066-c6d8-40f0-b1f3-52774f7b8f0b.jpg', 'IMG_20151114_131004639.jpg', '1317326', '2015-11-16 14:05:46', 97),
	(219, 'eb7dcde5-387d-4425-bcea-a60c5e991e47.jpg', 'IMG_20151114_131015459.jpg', '1281183', '2015-11-16 14:05:53', 97),
	(220, 'cd3ffd92-3561-40d5-9d86-67fe26b7387c.jpg', 'IMG_20151114_131026683.jpg', '1312867', '2015-11-16 14:06:01', 97),
	(221, '84bfa1ba-78a7-4c61-9a85-0c3c7e78099c.jpg', 'IMG_20151114_131040419.jpg', '1099195', '2015-11-16 14:06:08', 97),
	(224, '3464d67d-87ac-469e-a0c2-5289c87f1436.jpg', 'IMG_20151114_131647633.jpg', '1281607', '2015-11-16 14:07:17', 98),
	(225, '3d0f77bf-e29c-4d6f-95db-f9eacf020b94.jpg', 'IMG_20151114_131658480.jpg', '1130057', '2015-11-16 14:07:24', 98),
	(226, '030c6ca3-70f3-4074-9828-fde83f64bf4b.jpg', 'IMG_20151114_131851085.jpg', '1143526', '2015-11-16 14:07:31', 98),
	(227, '748421df-f50c-48c6-875f-5d2a4c707892.jpg', 'IMG_20151114_131856404.jpg', '1057190', '2015-11-16 14:07:39', 98),
	(228, '75db0423-25da-4c56-a0c6-d830c1ed7884.jpg', 'IMG_20151114_131631059.jpg', '1303344', '2015-11-16 14:08:31', 98),
	(229, 'ba0fb209-6630-43eb-aa9e-db52dd3320f6.jpg', 'IMG_20151114_132036497.jpg', '1339603', '2015-11-16 14:10:27', 102),
	(230, '90477773-496a-4db8-bc1f-2050fc42070f.jpg', 'IMG_20151114_131959687.jpg', '1338938', '2015-11-16 14:11:13', 102),
	(231, '39051dd7-b6d3-4751-a246-b5a316a0a72a.jpg', 'IMG_20151114_132011079.jpg', '1477288', '2015-11-16 14:11:21', 102),
	(233, 'f4b02e84-f38f-4005-8b18-d7f67cd1fbb0.jpg', 'IMG_20151114_131909704.jpg', '1277032', '2015-11-16 14:12:31', 103),
	(234, '87daac4e-4556-443d-9e29-96fd63fa15ea.jpg', 'IMG_20151114_131924961.jpg', '1226658', '2015-11-16 14:12:38', 103),
	(235, '9d279db6-c5d5-4a82-87e3-e4cabdbf6b86.jpg', 'IMG_20151114_132024447.jpg', '1181878', '2015-11-16 14:13:03', 102),
	(236, '019ff2e0-2f12-4772-8bbb-4f62c0f6c069.jpg', 'IMG_20151114_132108320.jpg', '1163014', '2015-11-16 14:14:37', 104),
	(237, 'f2c01b6c-32da-43a0-9233-23cb679cee5f.jpg', 'IMG_20151114_132138950.jpg', '1137713', '2015-11-16 14:14:44', 104),
	(238, 'c8bb0b0e-8de5-4cdd-a169-b7b775106d4f.jpg', 'IMG_20151114_132258156.jpg', '1179542', '2015-11-16 14:14:51', 104),
	(239, 'd79971f8-5169-4f45-b4ed-e5e5bf6045d0.jpg', 'IMG_20151114_132313061.jpg', '1226429', '2015-11-16 14:14:59', 104),
	(240, '131cda64-fbea-43b3-9daf-9ed77ff74c59.jpg', 'IMG_20151114_132405247.jpg', '1273700', '2015-11-16 14:15:06', 104),
	(242, 'fe64eb2f-c2bf-45e8-a317-81cb2ab3b735.jpg', 'IMG_20151114_123153089.jpg', '1165459', '2015-11-16 14:42:52', 111),
	(243, '484c3ef2-c758-4093-93b5-40bcf16773d3.jpg', 'IMG_20151114_123057027.jpg', '1069253', '2015-11-16 14:43:25', 111),
	(244, 'd917d39f-bcc7-4837-873b-a884b5ccc97f.jpg', 'IMG_20151114_123129118.jpg', '1137503', '2015-11-16 14:43:32', 111),
	(245, 'e212c31c-f82d-4f3b-aaa7-dbed676609f2.jpg', 'IMG_20151114_123257268.jpg', '1328608', '2015-11-16 14:43:40', 111),
	(246, '495951dc-6e72-40a5-910d-e1474bfe4c61.jpg', 'IMG_20151114_124040377.jpg', '1312197', '2015-11-16 14:44:19', 112),
	(247, '327f7ee4-cc7a-4efe-8090-185d8eaf0f64.jpg', 'IMG_20151114_124022803.jpg', '1324285', '2015-11-16 14:44:48', 112),
	(248, '0c7d7f38-14f5-48c3-845a-521703e6f610.jpg', 'IMG_20151114_124056567.jpg', '1297408', '2015-11-16 14:44:55', 112),
	(249, '803cc956-1320-4308-98d2-d0b4ed4c7b05.jpg', 'IMG_20151114_124107387.jpg', '1268467', '2015-11-16 14:45:02', 112),
	(250, '03f67df2-f59a-40b4-b40b-34de746664aa.jpg', 'IMG_20151114_124006998.jpg', '1271799', '2015-11-16 14:45:26', 112),
	(251, '23dadb28-067f-446e-a91d-b4dbf9a45716.jpg', 'IMG_20151114_124149686.jpg', '1465912', '2015-11-16 14:46:13', 113),
	(252, '507d8369-9979-4371-a5c4-21dd7967e923.jpg', 'IMG_20151114_124201185.jpg', '1454578', '2015-11-16 14:46:20', 113),
	(253, '57528f10-6a5e-4223-a76a-ede7337f44c2.jpg', 'IMG_20151114_124214759.jpg', '1267475', '2015-11-16 14:52:45', 113),
	(254, '21675256-4965-4a3e-b420-36b7a8f80aea.jpg', 'IMG_20151114_124230980.jpg', '1391739', '2015-11-16 14:52:52', 113),
	(255, '82c7021d-22c9-4e16-a165-e87e5453081a.jpg', 'IMG_20151114_120920816.jpg', '1358741', '2015-11-16 14:54:04', 114),
	(256, '6c10659d-f68b-4e34-95ec-be8713937305.jpg', 'IMG_20151114_120909205.jpg', '1327090', '2015-11-16 14:54:56', 114),
	(257, '6868b23e-47a2-4b96-a019-cb3512d0775c.jpg', 'IMG_20151114_120951658.jpg', '1118671', '2015-11-16 14:55:03', 114),
	(258, '4faa3035-fe6a-4b0e-abaa-dbd1747da03f.jpg', 'IMG_20151114_121005203.jpg', '1014501', '2015-11-16 14:55:11', 114),
	(259, '8a706354-f1cc-42bd-81b7-e6ee8787be88.jpg', 'IMG_20151114_121212402.jpg', '1341191', '2015-11-16 14:55:18', 114),
	(260, 'f97e10df-a8ab-4eeb-b0f9-b7a2ce9f1743.jpg', 'IMG_20151114_124306842.jpg', '1334445', '2015-11-16 14:56:24', 110),
	(261, '4ffb82c6-4765-4748-a220-c7486fef60bd.jpg', 'IMG_20151114_124352568.jpg', '1266912', '2015-11-16 14:56:32', 110),
	(262, '4e3f2df2-650b-46ac-9994-85ae4d2a47ba.jpg', 'IMG_20151114_124404301.jpg', '1248046', '2015-11-16 14:56:39', 110),
	(263, 'e756ef40-0576-42f0-b694-02fa5e8e19f2.jpg', 'IMG_20151114_124417233.jpg', '1213590', '2015-11-16 14:56:46', 110),
	(264, '444f2c42-4e5f-4f1e-8587-56d4afa8c9df.jpg', 'IMG_20151114_122605022.jpg', '1365877', '2015-11-16 14:57:49', 109),
	(265, '3da17b82-9644-4864-9e8f-276034a77217.jpg', 'IMG_20151114_122618893.jpg', '1205270', '2015-11-16 14:57:57', 109),
	(266, 'b91929da-31fd-4191-b9a2-d0bd9d4b6dad.jpg', 'IMG_20151114_122750669.jpg', '1442552', '2015-11-16 14:58:04', 109),
	(267, '7c051028-f703-4840-9674-bef7b70f672f.jpg', 'IMG_20151114_122815523.jpg', '1219005', '2015-11-16 14:58:11', 109),
	(268, '7ab89b40-2053-4f49-a3f4-875e31792323.jpg', 'IMG_20151114_122545766.jpg', '1220782', '2015-11-16 14:59:24', 109),
	(269, '58fe490e-5ebb-47fe-855b-a0f85399ac44.jpg', 'IMG_20151114_130906292.jpg', '1202726', '2015-11-16 18:18:53', 107),
	(270, '5fdd82e4-1c21-4404-a09f-8b3aa0c1c0a8.jpg', 'IMG_20151114_130914764.jpg', '1216710', '2015-11-16 18:19:01', 107),
	(271, '51f7813e-b282-498e-86a7-8ce101b95791.jpg', 'IMG_20151114_130620415.jpg', '1160445', '2015-11-16 18:19:32', 107),
	(272, 'd069f52e-1674-465a-a6b9-323695bd7b4b.jpg', 'IMG_20151114_130655833.jpg', '1142366', '2015-11-16 18:19:39', 107),
	(273, '1c91508b-647f-4d4d-ad14-4095a92cf33f.jpg', 'IMG_20151114_121254315.jpg', '1220260', '2015-11-16 18:20:23', 106),
	(274, '321b639a-a434-4994-8260-14cb98c99eea.jpg', 'IMG_20151114_121524642.jpg', '1079769', '2015-11-16 18:20:30', 106),
	(275, '34930a00-3304-434e-849a-1ec9651901ad.jpg', 'IMG_20151114_121426773.jpg', '1277133', '2015-11-16 18:21:07', 106),
	(276, '23265762-4392-4c77-bdc3-c5f695d9f1c8.jpg', 'IMG_20151114_122234289.jpg', '1049605', '2015-11-16 18:21:14', 106),
	(277, 'b5c72784-b1e1-4569-817c-48ac72542e59.jpg', 'IMG_20151114_132208762.jpg', '1324215', '2015-11-16 18:31:00', 105),
	(278, 'e487329f-38fa-435e-b3da-5959f85a393e.jpg', 'IMG_20151114_132156861.jpg', '1314293', '2015-11-16 18:31:54', 105),
	(279, 'b3a4c275-dd15-45c8-a0e6-650d16550f40.jpg', 'IMG_20151114_132222094.jpg', '1206900', '2015-11-16 18:32:01', 105),
	(280, '5f6b4e0e-c963-4fd6-b930-b00f196c69d4.jpg', 'IMG_20151114_132237045.jpg', '1395909', '2015-11-16 18:32:08', 105),
	(281, '852ef05c-1327-443c-aa46-77f9d1ed7742.jpg', 'IMG_20151114_132435313.jpg', '1129425', '2015-11-16 18:32:16', 105),
	(282, '067627d5-5055-4823-8560-beaf9ff1f19c.jpg', 'IMG_20151114_125512332.jpg', '1470696', '2015-11-16 18:34:05', 115),
	(283, 'c6956085-7a66-4858-848c-898204447e5b.jpg', 'IMG_20151114_125522525.jpg', '1270920', '2015-11-16 18:34:12', 115),
	(284, '42e7a5fe-4125-4def-b92d-c95230ffdd9c.jpg', 'IMG_20151114_125800706.jpg', '1374099', '2015-11-16 18:35:36', 116),
	(285, 'de4c9871-2c8f-4b17-8429-3e7323e9910b.jpg', 'IMG_20151114_125814923.jpg', '1465466', '2015-11-16 18:35:43', 116),
	(286, 'c7ec7a1f-558c-4911-8dbb-5ad54f32ca32.jpg', 'IMG_20151114_133122473.jpg', '1298297', '2015-11-16 18:39:08', 117),
	(287, 'fbd673df-c64f-44e6-b831-6d60f2694ede.jpg', 'IMG_20151114_132843039.jpg', '1079353', '2015-11-16 18:39:43', 117),
	(288, '016987d3-e9e6-4745-8c53-d5e1fbe7c721.jpg', 'IMG_20151114_132902775.jpg', '1465474', '2015-11-16 18:39:51', 117),
	(289, 'b81678d8-61ac-4a56-88d6-17dce943ddf5.jpg', 'IMG_20151114_132916027.jpg', '1246905', '2015-11-16 18:39:58', 117),
	(290, 'a6c2effc-8cbf-419a-bc8c-e325b165172c.jpg', 'IMG_20151114_120649743.jpg', '1458758', '2015-11-16 18:48:17', 118),
	(291, 'f51f4fc2-49a8-4ccf-9ccd-5062460f064a.jpg', 'IMG_20151114_120705232.jpg', '1177955', '2015-11-16 18:49:07', 118),
	(292, '2772275e-8944-4db2-b61d-3b8324ce3114.jpg', 'IMG_20151114_120800861.jpg', '1390864', '2015-11-16 18:49:14', 118),
	(293, '1cad284c-189f-4309-97c0-ce6668ef2ef7.jpg', 'IMG_20151114_120811830.jpg', '1262112', '2015-11-16 18:49:22', 118),
	(294, 'bd73a161-b8f4-43c0-85e0-e72b4a9d9aca.jpg', 'IMG_20151114_120830783.jpg', '1057213', '2015-11-16 18:49:29', 118);
/*!40000 ALTER TABLE `arquivo` ENABLE KEYS */;


-- Copiando estrutura para tabela lojacarros.cliente
CREATE TABLE IF NOT EXISTS `cliente` (
  `IdCliente` int(11) NOT NULL auto_increment,
  `Estado` varchar(2) default '0',
  `Nome` varchar(50) NOT NULL,
  `Email` varchar(50) default NULL,
  `Telefone1` varchar(50) NOT NULL,
  `Telefone2` varchar(50) default NULL,
  `CEP` varchar(10) default NULL,
  `Logradouro` varchar(200) default NULL,
  `Bairro` varchar(50) default NULL,
  `Cidade` varchar(50) default NULL,
  `DataCadastro` datetime NOT NULL,
  PRIMARY KEY  (`IdCliente`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- Copiando dados para a tabela lojacarros.cliente: ~1 rows (aproximadamente)
/*!40000 ALTER TABLE `cliente` DISABLE KEYS */;
INSERT INTO `cliente` (`IdCliente`, `Estado`, `Nome`, `Email`, `Telefone1`, `Telefone2`, `CEP`, `Logradouro`, `Bairro`, `Cidade`, `DataCadastro`) VALUES
	(1, 'RJ', 'Davi França Maciel', 'davifrancamaciel@hotmail.com', '(24) 99395-4479', '(24) 9939-5447', '25615-071', 'Rua Elyzio Alves', 'Caxambu', 'Rua Elyzio Alves', '2015-09-23 17:54:15');
/*!40000 ALTER TABLE `cliente` ENABLE KEYS */;


-- Copiando estrutura para tabela lojacarros.combustivel
CREATE TABLE IF NOT EXISTS `combustivel` (
  `IdCombustivel` int(11) NOT NULL auto_increment,
  `Nome` varchar(50) NOT NULL,
  PRIMARY KEY  (`IdCombustivel`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;

-- Copiando dados para a tabela lojacarros.combustivel: ~10 rows (aproximadamente)
/*!40000 ALTER TABLE `combustivel` DISABLE KEYS */;
INSERT INTO `combustivel` (`IdCombustivel`, `Nome`) VALUES
	(1, 'GASOLINA'),
	(2, 'ALCOOL'),
	(3, 'FLEX'),
	(4, 'DIESEL'),
	(5, 'ETANOL'),
	(6, 'GASOLINA + GNV'),
	(7, 'ALCOOL + GNV'),
	(8, 'DIESEL + GNV'),
	(9, 'ETANOL + GNV'),
	(10, 'FLEX + GNV');
/*!40000 ALTER TABLE `combustivel` ENABLE KEYS */;


-- Copiando estrutura para tabela lojacarros.estado
CREATE TABLE IF NOT EXISTS `estado` (
  `Sigla` varchar(2) NOT NULL,
  PRIMARY KEY  (`Sigla`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Copiando dados para a tabela lojacarros.estado: ~27 rows (aproximadamente)
/*!40000 ALTER TABLE `estado` DISABLE KEYS */;
INSERT INTO `estado` (`Sigla`) VALUES
	('AC'),
	('AL'),
	('AM'),
	('AP'),
	('BA'),
	('CE'),
	('DF'),
	('ES'),
	('GO'),
	('MA'),
	('MG'),
	('MS'),
	('MT'),
	('PA'),
	('PB'),
	('PE'),
	('PI'),
	('PR'),
	('RJ'),
	('RN'),
	('RO'),
	('RR'),
	('RS'),
	('SC'),
	('SE'),
	('SP'),
	('TO');
/*!40000 ALTER TABLE `estado` ENABLE KEYS */;


-- Copiando estrutura para tabela lojacarros.foto
CREATE TABLE IF NOT EXISTS `foto` (
  `IdFoto` int(11) NOT NULL auto_increment,
  `NomeAnterior` varchar(150) NOT NULL,
  `ExtensaoArquivo` varchar(50) NOT NULL,
  `TipoArquivo` varchar(50) NOT NULL,
  `Nome` varchar(150) NOT NULL,
  `IdVeiculo` int(11) NOT NULL,
  PRIMARY KEY  (`IdFoto`),
  KEY `IdVeiculo` (`IdVeiculo`),
  CONSTRAINT `IdVeiculos` FOREIGN KEY (`IdVeiculo`) REFERENCES `veiculo` (`IdVeiculo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Copiando dados para a tabela lojacarros.foto: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `foto` DISABLE KEYS */;
/*!40000 ALTER TABLE `foto` ENABLE KEYS */;


-- Copiando estrutura para tabela lojacarros.marca
CREATE TABLE IF NOT EXISTS `marca` (
  `IdMarca` int(11) NOT NULL auto_increment,
  `Nome` varchar(50) NOT NULL,
  `IdTipo` int(11) NOT NULL,
  `DataCadastro` datetime default NULL,
  PRIMARY KEY  (`IdMarca`),
  KEY `IdTipo` (`IdTipo`),
  CONSTRAINT `IdTipo` FOREIGN KEY (`IdTipo`) REFERENCES `tipo` (`IdTipo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=latin1;

-- Copiando dados para a tabela lojacarros.marca: ~14 rows (aproximadamente)
/*!40000 ALTER TABLE `marca` DISABLE KEYS */;
INSERT INTO `marca` (`IdMarca`, `Nome`, `IdTipo`, `DataCadastro`) VALUES
	(1, 'GM-CHEVROLET', 1, '2015-10-22 12:18:45'),
	(2, 'FIAT', 1, '2015-09-22 11:13:50'),
	(4, 'WOLKSWAGEN', 1, '2015-09-22 11:13:50'),
	(6, 'YAMAHA', 2, '2015-09-22 11:13:50'),
	(7, 'HONDA', 2, '2015-09-22 11:13:50'),
	(8, 'PEUGEOT', 1, '2015-09-22 11:13:50'),
	(10, 'HONDA', 1, '2015-09-22 11:13:50'),
	(15, 'trax', 2, '2015-09-22 11:13:50'),
	(17, 'KAVASAKI', 2, '2015-09-22 11:13:50'),
	(22, 'sundown', 2, '2015-09-22 11:13:50'),
	(23, 'BMW', 1, '2015-10-31 12:38:39'),
	(24, 'FORD', 1, '2015-11-14 11:13:34'),
	(25, 'kia', 1, '2015-11-14 11:28:12'),
	(26, 'renaut', 1, '2015-11-18 15:07:16');
/*!40000 ALTER TABLE `marca` ENABLE KEYS */;


-- Copiando estrutura para procedure lojacarros.procMarcaByIdTipoSELECT
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `procMarcaByIdTipoSELECT`(IN `idTipo` INT)
BEGIN



SELECT 

M.IdMarca, M.Nome 

FROM Marca AS M 


INNER JOIN Tipo AS T ON T.IdTipo = M.IdTipo            


WHERE ( T.IdTipo = idTipo OR idTipo IS NULL);


END//
DELIMITER ;


-- Copiando estrutura para procedure lojacarros.procMarcaByTipoSELECT
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `procMarcaByTipoSELECT`(IN `idTipo` VARCHAR(50), IN `ativo` INT)
BEGIN



SELECT DISTINCT 


COUNT(IdVeiculo) AS QtdVeiculo, T.Nome AS TipoNome,

M.IdMarca, M.Nome 

FROM Marca AS M 

LEFT JOIN Veiculo AS V on V.IdMarca = M.IdMarca       
INNER JOIN Tipo AS T ON T.IdTipo = M.IdTipo            


WHERE (V.Ativo = ativo OR ativo IS NULL) AND 
		( T.Nome = idTipo OR idTipo IS NULL) 
		
		GROUP BY M.IdMarca;


END//
DELIMITER ;


-- Copiando estrutura para procedure lojacarros.procMarcaSELECT
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `procMarcaSELECT`(IN `idMarca` INT)
BEGIN



SELECT 

M.IdMarca, M.Nome ,T.Nome AS NomeTipo, M.IdTipo, DataCadastro

FROM Marca AS M 

INNER JOIN Tipo AS T on T.IdTipo = M.IdTipo


WHERE  M.IdMarca = idMarca OR idMarca IS NULL ORDER BY M.Nome;


END//
DELIMITER ;


-- Copiando estrutura para procedure lojacarros.procVeiculoByFiltroSELECT
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `procVeiculoByFiltroSELECT`(IN `TipoV` VARCHAR(50), IN `MarcaV` VARCHAR(50), IN `AnoInicio` VARCHAR(50), IN `AnoFim` VARCHAR(50))
BEGIN


IF (AnoInicio is NULL )THEN
SELECT MIN(AnoFabricacao) into AnoInicio FROM Veiculo; 
END IF;

IF (AnoFim is NULL) THEN
SELECT MAX(AnoFabricacao) into AnoFim FROM Veiculo;
END IF;


SELECT 
C.Nome AS CombustivelNome, 
T.Nome, M.Nome AS MarcaNome, 
V.AnoFabricacao, Modelo, Valor, V.IdVeiculo, AnoModelo, 
MIN(IdArquivo) As MinArquivo, A.Nome AS aNome

FROM Veiculo AS V 
INNER JOIN Marca AS M ON M.IdMarca = V.IdMarca 
INNER JOIN Tipo AS T ON T.IdTipo = M.IdTipo 
INNER JOIN Combustivel AS C ON C.IdCombustivel = V.IdCombustivel 
LEFT JOIN Arquivo AS A ON A.IdVeiculo = V.IdVeiculo 



WHERE (T.Nome = TipoV OR TipoV IS NULL) AND 
		(M.Nome = MarcaV OR MarcaV IS NULL) AND 
		(V.AnoFabricacao BETWEEN AnoInicio AND AnoFim) AND Ativo = 1 GROUP BY V.IdVeiculo ORDER BY V.DataCadastro DESC;

 
 END//
DELIMITER ;


-- Copiando estrutura para procedure lojacarros.procVeiculoSELECT
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `procVeiculoSELECT`(IN `idVeiculo` INT, IN `ativo` INT)
BEGIN


SELECT 

C.Nome AS CombustivelNome, 
T.Nome, M.IdTipo as idTipo, M.Nome AS MarcaNome, M.IdMarca as IdMarca,  
V.AnoFabricacao, Modelo, Valor, Descricao, V.IdVeiculo, AnoModelo, QtdAcesso, Destaque, V.Ativo, V.IdCombustivel as idCombustivel,
V.DataCadastro, 
MIN(IdArquivo) As MinArquivo, A.Nome AS aNome

FROM Veiculo AS V 
INNER JOIN Marca AS M ON M.IdMarca = V.IdMarca 
INNER JOIN Tipo AS T ON T.IdTipo = M.IdTipo 
INNER JOIN Combustivel AS C ON C.IdCombustivel = V.IdCombustivel 
LEFT JOIN Arquivo AS A ON A.IdVeiculo = V.IdVeiculo 



WHERE (V.Ativo = ativo OR ativo IS NULL) AND 
		(V.IdVeiculo = idVeiculo OR idVeiculo IS NULL) GROUP BY V.IdVeiculo ORDER BY V.DataCadastro DESC; 
		

END//
DELIMITER ;


-- Copiando estrutura para tabela lojacarros.tipo
CREATE TABLE IF NOT EXISTS `tipo` (
  `IdTipo` int(11) NOT NULL auto_increment,
  `Nome` varchar(50) NOT NULL,
  PRIMARY KEY  (`IdTipo`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

-- Copiando dados para a tabela lojacarros.tipo: ~2 rows (aproximadamente)
/*!40000 ALTER TABLE `tipo` DISABLE KEYS */;
INSERT INTO `tipo` (`IdTipo`, `Nome`) VALUES
	(1, 'Carro'),
	(2, 'Moto');
/*!40000 ALTER TABLE `tipo` ENABLE KEYS */;


-- Copiando estrutura para tabela lojacarros.usuario
CREATE TABLE IF NOT EXISTS `usuario` (
  `IdUsuario` int(11) NOT NULL auto_increment,
  `Email` varchar(50) NOT NULL,
  `Senha` varchar(100) NOT NULL,
  PRIMARY KEY  (`IdUsuario`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=latin1;

-- Copiando dados para a tabela lojacarros.usuario: ~2 rows (aproximadamente)
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` (`IdUsuario`, `Email`, `Senha`) VALUES
	(8, 'davifrancamaciel@hotmail.com', 'c2ad4d76fe97759aa27a0c99bff6710'),
	(13, 'davi', '86a08a8cd53357d3fb437a6810af55cc');
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;


-- Copiando estrutura para tabela lojacarros.veiculo
CREATE TABLE IF NOT EXISTS `veiculo` (
  `IdVeiculo` int(11) NOT NULL auto_increment,
  `AnoFabricacao` int(4) NOT NULL,
  `AnoModelo` int(4) NOT NULL,
  `Ativo` int(1) NOT NULL,
  `Destaque` int(1) NOT NULL,
  `Descricao` varchar(4000) NOT NULL,
  `Modelo` varchar(50) NOT NULL,
  `DataCadastro` datetime NOT NULL,
  `Valor` decimal(10,0) default NULL,
  `IdMarca` int(11) NOT NULL,
  `QtdAcesso` int(11) default NULL,
  `IdCombustivel` int(11) NOT NULL,
  PRIMARY KEY  (`IdVeiculo`),
  KEY `IdMarca` (`IdMarca`),
  KEY `IdCombustivel` (`IdCombustivel`),
  CONSTRAINT `IdCombustivel` FOREIGN KEY (`IdCombustivel`) REFERENCES `combustivel` (`IdCombustivel`),
  CONSTRAINT `IdMarca` FOREIGN KEY (`IdMarca`) REFERENCES `marca` (`IdMarca`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=121 DEFAULT CHARSET=latin1;

-- Copiando dados para a tabela lojacarros.veiculo: ~30 rows (aproximadamente)
/*!40000 ALTER TABLE `veiculo` DISABLE KEYS */;
INSERT INTO `veiculo` (`IdVeiculo`, `AnoFabricacao`, `AnoModelo`, `Ativo`, `Destaque`, `Descricao`, `Modelo`, `DataCadastro`, `Valor`, `IdMarca`, `QtdAcesso`, `IdCombustivel`) VALUES
	(90, 1995, 1995, 1, 0, 'Branca Bom estado de conservação poco rodada. Documentos ok.', 'kombi', '2015-11-14 11:10:19', 0, 4, NULL, 1),
	(91, 2003, 2003, 1, 0, 'Preto completo com rodas de liga leve e  para-choques na cor do carro.', 'Ka', '2015-11-14 11:14:56', 0, 24, NULL, 1),
	(92, 1999, 1999, 1, 0, 'Vidros elétricos pneus novos', 'ka', '2015-11-14 11:17:24', 0, 24, NULL, 1),
	(93, 1989, 1989, 1, 0, 'Grafite, rodas de liga leve, vidros elétricos.', 'kadet', '2015-11-14 11:19:14', 0, 1, NULL, 1),
	(94, 1995, 1995, 1, 0, 'GTI completo + teto solar preto e rodas de liga leve aro 15. ', 'Golf', '2015-11-14 11:20:48', 0, 4, NULL, 6),
	(95, 2002, 2002, 1, 0, 'Branco completo rodas de liga leve.', 'astra-sedan', '2015-11-14 11:24:36', 0, 1, NULL, 6),
	(96, 2002, 2002, 1, 0, 'Grafite, 4 portas + vidros elétricos, ar condicionado e alarme.', 'fiesta', '2015-11-14 11:26:04', 0, 24, NULL, 6),
	(97, 1997, 1997, 1, 0, 'Cinza chumbo, 4 portas, pneus novos e vidros elétricos.', 'uno', '2015-11-14 11:27:56', 0, 2, NULL, 1),
	(98, 1995, 1995, 1, 0, 'Prata, Pneus novos, estepe 0 Km, completa.', 'sportage', '2015-11-14 11:29:42', 0, 25, NULL, 1),
	(99, 1995, 1995, 1, 0, 'Vermelho, Básico, rodas de liga leve e para-choques na cor do carro.', 'gol-bola', '2015-11-14 11:32:28', 0, 4, NULL, 1),
	(100, 1996, 1996, 1, 0, 'Grafite vidros elétricos rodas de liga leve pneus novos (placa 1609)', 'kadet', '2015-11-14 11:34:05', 0, 1, NULL, 6),
	(101, 1996, 1996, 1, 0, 'Verde com ar condicionado.', 'blazer', '2015-11-14 11:34:58', 0, 1, NULL, 6),
	(102, 1998, 1998, 1, 0, 'Azul, 4.3, V6, completa de tudo e cambio automático ', 'blazer', '2015-11-14 11:36:21', 0, 1, NULL, 4),
	(103, 1999, 1999, 1, 0, 'Azul completo + Airbag', '406', '2015-11-14 11:38:00', 0, 8, NULL, 6),
	(104, 2006, 2006, 1, 1, 'Branco 1.4 pneus novos rodas de liga leve completo', 'palio-weekend', '2015-11-14 11:39:37', 0, 2, NULL, 6),
	(105, 2007, 2007, 1, 1, 'Prata, Pneus novos, 2 portas, vidros elétricos VHC 1.0, ar condicionado, Trava e alarme.', 'celta', '2015-11-14 11:41:38', 0, 1, NULL, 1),
	(106, 2008, 2008, 1, 1, 'Prata, 4 Portas, pneus novos, completo 1.6', 'fox', '2015-11-14 11:42:43', 0, 4, NULL, 1),
	(107, 2001, 2001, 1, 0, 'Prata completo 2.2 motor MPFI ', 'vectra-milenium', '2015-11-14 11:44:31', 0, 1, NULL, 1),
	(108, 2008, 2008, 1, 0, 'preta básica pneus novos.', 'uno-mille-fire', '2015-11-16 08:58:52', 0, 2, NULL, 1),
	(109, 2008, 2008, 1, 1, 'completo 2 portas pneus novos 1.0 fire', 'palio-azul', '2015-11-16 09:01:15', 0, 2, NULL, 3),
	(110, 2001, 2001, 1, 0, 'cinza chumbo LX completo cambio automático.', 'civic', '2015-11-16 09:02:35', 0, 10, NULL, 1),
	(111, 2005, 2005, 1, 0, 'spirit com ar e trava. 1.0', 'celta-prata-2p', '2015-11-16 09:03:37', 0, 1, NULL, 1),
	(112, 2004, 2004, 1, 1, 'preto completo sensor de ré rodas de liga leve estofado em couro  cambio manual.', '307-SW', '2015-11-16 09:05:26', 0, 8, NULL, 1),
	(113, 2001, 2001, 1, 0, 'verde completo rodas de liga leve pneus novos.', 'palio-weekend', '2015-11-16 09:06:50', 0, 2, NULL, 1),
	(114, 2011, 2011, 1, 1, 'Prata spirit 4 portas rodas de liga leve aro 15 de astra motor VHCE  completo com apenas 45.000 KMs e pneus novos.', 'celta-prata-4p', '2015-11-16 09:09:02', 0, 1, NULL, 3),
	(115, 2002, 2002, 1, 0, 'Com baú e pouco rodada.', 'XT-600', '2015-11-13 18:33:39', 0, 6, NULL, 1),
	(116, 2006, 2006, 1, 0, 'Com baixa KM e com cano coyote esportivo.', 'TWISTER', '2015-11-13 18:35:17', 0, 7, NULL, 1),
	(117, 2001, 2001, 1, 0, 'Verde, Completa muito nova.', 'blazer', '2015-11-16 18:38:48', 0, 1, NULL, 8),
	(118, 2005, 2005, 0, 1, 'Preto, Elite, 4 Portas, rodas de liga leve aro 17, pneus novos, estofado em couro, cambio automático, completo de tudo 2.0', 'astra-preto', '2015-11-16 18:47:48', 0, 1, NULL, 3),
	(120, 2015, 2015, 0, 0, 'eee', 'eee', '2015-12-03 00:56:56', 0, 1, NULL, 9);
/*!40000 ALTER TABLE `veiculo` ENABLE KEYS */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;

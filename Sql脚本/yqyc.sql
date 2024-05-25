/*
 Navicat Premium Data Transfer

 Source Server         : huaian
 Source Server Type    : MySQL
 Source Server Version : 80026 (8.0.26)
 Source Host           : localhost:3306
 Source Schema         : yqyc

 Target Server Type    : MySQL
 Target Server Version : 80026 (8.0.26)
 File Encoding         : 65001

 Date: 25/05/2024 20:37:50
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for car
-- ----------------------------
DROP TABLE IF EXISTS `car`;
CREATE TABLE `car`  (
  `Id` int NOT NULL,
  `Vin` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CarType` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '0',
  `Brand` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Factory` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Cyqdm` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Clsbdh` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Sfx` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Csys` varchar(10) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Cllx` varchar(5) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Status` int NOT NULL,
  `Other` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `IsManual` int NOT NULL DEFAULT 0,
  `DisplayFinish` bit(1) NULL DEFAULT b'0',
  `UserId` int NULL DEFAULT NULL,
  `UserName` varchar(20) CHARACTER SET armscii8 COLLATE armscii8_bin NULL DEFAULT NULL,
  `PhotoEnabled` bit(1) NOT NULL DEFAULT b'0',
  `CameraEnabled` bit(1) NOT NULL DEFAULT b'0',
  `CarAllPhotoOK` bit(1) NOT NULL DEFAULT b'0',
  `IsCreatePdf` bit(1) NOT NULL DEFAULT b'0',
  `ExcuteCheckInterface` bit(1) NOT NULL DEFAULT b'0',
  `StandardImageCommit` bit(1) NOT NULL DEFAULT b'0',
  `CreateDate` datetime NOT NULL,
  `UpdateDate` datetime NOT NULL,
  `CarBodyCode` varchar(100) CHARACTER SET armscii8 COLLATE armscii8_bin NULL DEFAULT NULL
) ENGINE = InnoDB CHARACTER SET = armscii8 COLLATE = armscii8_bin ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of car
-- ----------------------------
INSERT INTO `car` VALUES (1, '11', '223', '3', '3', NULL, '3', '3', '3', '3', 1, NULL, 0, b'0', NULL, NULL, b'0', b'0', b'0', b'0', b'0', b'0', '2024-01-13 20:22:43', '2024-01-13 20:22:40', NULL);

-- ----------------------------
-- Table structure for cartypesize
-- ----------------------------
DROP TABLE IF EXISTS `cartypesize`;
CREATE TABLE `cartypesize`  (
  `Id` int NOT NULL,
  `CarType` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `CarTypeName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `X` double NULL DEFAULT NULL,
  `Y` double NULL DEFAULT NULL,
  `Width` double NULL DEFAULT NULL,
  `Height` double NULL DEFAULT NULL,
  `CreateDate` datetime NOT NULL,
  `UpdateDate` datetime NOT NULL
) ENGINE = InnoDB CHARACTER SET = armscii8 COLLATE = armscii8_bin ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of cartypesize
-- ----------------------------

-- ----------------------------
-- Table structure for device
-- ----------------------------
DROP TABLE IF EXISTS `device`;
CREATE TABLE `device`  (
  `Id` int NOT NULL,
  `Name` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Type` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `IpAddress` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Port` int NULL DEFAULT NULL,
  `UserName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Password` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `CreateDate` datetime NOT NULL,
  `UpdateDate` datetime NOT NULL,
  `Position` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL
) ENGINE = InnoDB CHARACTER SET = armscii8 COLLATE = armscii8_bin ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of device
-- ----------------------------

-- ----------------------------
-- Table structure for dictionary
-- ----------------------------
DROP TABLE IF EXISTS `dictionary`;
CREATE TABLE `dictionary`  (
  `Id` int NOT NULL,
  `Name` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `CreateDate` datetime NOT NULL,
  `UpdateDate` datetime NOT NULL
) ENGINE = InnoDB CHARACTER SET = armscii8 COLLATE = armscii8_bin ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of dictionary
-- ----------------------------

-- ----------------------------
-- Table structure for dictionarycode
-- ----------------------------
DROP TABLE IF EXISTS `dictionarycode`;
CREATE TABLE `dictionarycode`  (
  `Id` int NOT NULL,
  `Name` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Code` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `ParentId` int NULL DEFAULT NULL,
  `Value` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Remark` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `CreateDate` datetime NULL DEFAULT NULL,
  `UpdateDate` datetime NULL DEFAULT NULL
) ENGINE = InnoDB CHARACTER SET = armscii8 COLLATE = armscii8_bin ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of dictionarycode
-- ----------------------------

-- ----------------------------
-- Table structure for uploadfile
-- ----------------------------
DROP TABLE IF EXISTS `uploadfile`;
CREATE TABLE `uploadfile`  (
  `Id` int NOT NULL,
  `Vin` varchar(200) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Sort` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Type` int NULL DEFAULT NULL,
  `Position` int NULL DEFAULT NULL,
  `FilePath` varchar(200) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `IsOk` bit(1) NULL DEFAULT NULL,
  `Status` int NULL DEFAULT NULL,
  `VisionCode` varchar(200) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `ErrorMsg` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `CreateDate` datetime NOT NULL,
  `UpdateDate` datetime NOT NULL,
  `CarId` int NULL DEFAULT NULL
) ENGINE = InnoDB CHARACTER SET = armscii8 COLLATE = armscii8_bin ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of uploadfile
-- ----------------------------
INSERT INTO `uploadfile` VALUES (2, '111', '1', 1, 1, '1', b'1', 1, '1', '12', '2024-01-13 20:22:12', '2024-01-13 20:22:14', 1);
INSERT INTO `uploadfile` VALUES (1, '111', '1', 1, 1, '1', b'1', 1, '1', '12', '2024-01-13 20:22:12', '2024-01-13 20:22:14', 1);

-- ----------------------------
-- Table structure for userinfo
-- ----------------------------
DROP TABLE IF EXISTS `userinfo`;
CREATE TABLE `userinfo`  (
  `Id` int NOT NULL,
  `Account` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `UserName` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `PassWord` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `PhotoPermission` bit(1) NOT NULL,
  `CreateDate` datetime NOT NULL,
  `UpdateDate` datetime NOT NULL
) ENGINE = InnoDB CHARACTER SET = armscii8 COLLATE = armscii8_bin ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of userinfo
-- ----------------------------

SET FOREIGN_KEY_CHECKS = 1;

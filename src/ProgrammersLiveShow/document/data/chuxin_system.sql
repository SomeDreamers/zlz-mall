/*
Navicat MySQL Data Transfer

Source Server         : 115.28.103.116
Source Server Version : 50634
Source Host           : 115.28.103.116:3306
Source Database       : chuxin_system_test

Target Server Type    : MYSQL
Target Server Version : 50634
File Encoding         : 65001

Date: 2017-03-13 21:44:57
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for __EFMigrationsHistory
-- ----------------------------
DROP TABLE IF EXISTS `__EFMigrationsHistory`;
CREATE TABLE `__EFMigrationsHistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of __EFMigrationsHistory
-- ----------------------------
INSERT INTO `__EFMigrationsHistory` VALUES ('20161116062414_init', '1.0.1');
INSERT INTO `__EFMigrationsHistory` VALUES ('20161122052130_addorder', '1.0.1');
INSERT INTO `__EFMigrationsHistory` VALUES ('20161124084827_addShopCount', '1.0.1');
INSERT INTO `__EFMigrationsHistory` VALUES ('20161128065801_deletebug', '1.0.1');
INSERT INTO `__EFMigrationsHistory` VALUES ('20161130054009_updatedata_order', '1.0.1');
INSERT INTO `__EFMigrationsHistory` VALUES ('20161130080533_addcommentshopsku_id', '1.0.1');
INSERT INTO `__EFMigrationsHistory` VALUES ('20161206052454_addorderDetail_delete', '1.0.1');
INSERT INTO `__EFMigrationsHistory` VALUES ('20161206055939_addtable_userapply', '1.0.1');
INSERT INTO `__EFMigrationsHistory` VALUES ('20161206104334_addorderDetail_evaldate', '1.0.1');
INSERT INTO `__EFMigrationsHistory` VALUES ('20161208084836_user_addfullname', '1.0.1');
INSERT INTO `__EFMigrationsHistory` VALUES ('20161214031409_updateMessage', '1.0.1');
INSERT INTO `__EFMigrationsHistory` VALUES ('20161219024026_updatedatabase_length', '1.0.1');
INSERT INTO `__EFMigrationsHistory` VALUES ('20161220101733_update_database_status', '1.0.1');
INSERT INTO `__EFMigrationsHistory` VALUES ('20170311133514_update_shopsize', '1.1.0-rtm-22752');

-- ----------------------------
-- Table structure for Pls_ButtonAction
-- ----------------------------
DROP TABLE IF EXISTS `Pls_ButtonAction`;
CREATE TABLE `Pls_ButtonAction` (
  `action_id` varchar(127) NOT NULL,
  `action_event` varchar(64) DEFAULT NULL,
  `action_icon` varchar(64) DEFAULT NULL,
  `action_name` varchar(128) NOT NULL,
  `action_newaction` bit(1) NOT NULL,
  `action_parentid` varchar(64) DEFAULT NULL,
  `action_sort` int(11) NOT NULL DEFAULT '1',
  `action_type` int(11) NOT NULL DEFAULT '2',
  `action_url` varchar(128) DEFAULT NULL,
  `createtime` datetime(6) NOT NULL,
  `disable` int(11) NOT NULL DEFAULT '0',
  `disabledesc` longtext,
  `row_number` longblob,
  PRIMARY KEY (`action_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of Pls_ButtonAction
-- ----------------------------
INSERT INTO `Pls_ButtonAction` VALUES ('07e2b180c3b24a98992c4b95017d72fe', 'btnStart', 'icon-unlock', '启用', '\0', '2873856d56224b8db68b8ada1f1a0bca', '7', '3', '/Admin/User/Disable', '2016-10-11 10:39:54.003325', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('0c3d3b6c1fd848e0bd3c0af660f36f41', 'btnEditDepart', 'icon-edit', '修改', '\0', '9b1e5dfb54f847dba654c45a9edab27f', '2', '3', '/Admin/Department/Update', '2016-10-11 10:09:09.559944', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('0c8967bc8411440d8eb21b77bfa97ebb', 'btnAddNotice', 'icon-plus', '添加', '\0', '4944bb424dd746be9622fb1327626419', '1', '3', '/Admin/Notice/Add', '2016-11-28 15:01:27.864013', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('0d0786209da3427c9b285ad67add1366', null, null, '部门查询', '\0', '5e2a6fc2c56e49c58ab1c6cc6984747d', '1', '4', '/Admin/Department/List', '2016-10-10 21:58:05.944879', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('0d3fbd8895504e858fd54dfc561afc19', 'btnStart', 'icon-unlock', '启用', '\0', '9b1e5dfb54f847dba654c45a9edab27f', '3', '3', '/Admin/Department/Disable', '2016-10-11 10:10:22.143241', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('0f358ad7be134f909ac467f8cc14475c', null, null, '根据商品Id查询商品', '\0', 'b8cdf103d2d94765b3daa148de8dc946', '17', '5', '/Admin/Shop/GetById', '2016-11-18 19:38:14.800925', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('1020ee13119946bba16442b624c2c3ba', null, null, '商品查询', '\0', '5e2a6fc2c56e49c58ab1c6cc6984747d', '5', '4', '/Admin/Shop/List', '2016-11-17 10:06:00.398101', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('106ae703a29a4e9fbb4372ca3f101068', null, 'icon-money', '订单管理', '', '42f93db68ab1454a88339169b4c1f781', '3', '2', '/Admin/Order/Index', '2016-11-26 21:29:30.398799', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('10f146052fcb4c19be6d6fc30f10faef', null, null, '权限查询', '\0', '5e2a6fc2c56e49c58ab1c6cc6984747d', '4', '4', '/Admin/ButtonAction/List', '2016-10-10 22:12:04.147588', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('142e445581c5452aa49b132a737bf8f4', null, 'icon-envelope', '留言管理', '', 'ca532a67f64745268314d222c0037c28', '1', '2', '/Admin/Message/Index', '2016-10-20 15:00:14.379774', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('15748e54f0c74c48aba5dbfba70de04a', 'btnAddShop', 'icon-plus', '添加', '\0', 'b8cdf103d2d94765b3daa148de8dc946', '1', '3', '/Admin/Shop/AddShop', '2016-11-15 21:58:54.507270', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('15869529e4b54322b764b1ad196d15f8', null, null, '根据商品ID查询商品图片', '\0', 'b8cdf103d2d94765b3daa148de8dc946', '23', '5', '/Admin/Shop/GetShopImageById', '2016-11-19 02:16:58.789952', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('159b60bd57cd462c89349c109ab32d85', 'btnDetail', 'icon-book', '详情', '\0', '106ae703a29a4e9fbb4372ca3f101068', '6', '3', '/Admin/Order/GetOrderById', '2016-11-29 18:08:06.481301', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('15c786f0db5d460fabbbc807ce237393', 'btnSetFavorable', 'icon-heart', '设置优惠', '\0', 'b8cdf103d2d94765b3daa148de8dc946', '3', '3', '/', '2016-11-19 03:38:53.494611', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('183e0bb7e7cc44eda5272ccca960e227', 'btnDetail', 'icon-book', '详情', '\0', '4944bb424dd746be9622fb1327626419', '5', '3', '/Admin/Notice/GetById', '2016-11-28 15:52:15.138143', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('1aaa477999b3491aa5318e598979d791', null, 'icon-comments', '评论管理', '', '42f93db68ab1454a88339169b4c1f781', '5', '2', '/Admin/Comment/Index', '2016-11-03 16:25:02.080372', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('1aad6290cc2d41b5b078794546558b47', 'btnForbidden', 'icon-lock', '禁用', '\0', '106ae703a29a4e9fbb4372ca3f101068', '4', '3', '/Admin/Order/Disable', '2016-11-29 18:06:46.149451', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('1f2b2c30c45b4bf0ab8691cf1e778b2c', 'btnStart', 'icon-unlock', '启用', '\0', 'd42ce5046f48442a86052a946be18544', '5', '3', '/Admin/ButtonAction/Disable', '2016-10-11 10:58:59.195932', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('1f3b9338b2f84e9f9e9bd6587b9cf3fd', null, null, '申请访问后台查询', '\0', '5e2a6fc2c56e49c58ab1c6cc6984747d', '10', '4', '/Admin/UserApply/List', '2016-12-10 14:14:47.902149', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('23b1c26eeefe4d2f8cbb9f6c6cddec44', null, null, '今日注册用户', '\0', 'faf9929ad1cb481b9402319ee8c8404b', '1', '5', '/Admin/Home/GetUserInfo', '2016-10-10 17:54:47.974615', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('23df0b86927c498a90af9fa9eb306b5d', 'btnDetail', 'icon-book', '详情', '\0', 'b8cdf103d2d94765b3daa148de8dc946', '6', '3', '/Admin/Shop/GetById', '2016-11-19 03:41:03.767236', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('2873856d56224b8db68b8ada1f1a0bca', null, 'icon-user', '用户管理', '', '88be3c8883b341cc98d6bfc24e0000e9', '3', '2', '/Admin/User/Index', '2016-10-10 11:14:39.898075', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('2c5ed44f8d8a4e67a328e80eb71b78ed', null, null, '商品SKU-DronDown加载', '\0', 'b8cdf103d2d94765b3daa148de8dc946', '13', '5', '/Admin/Shop/GetShopSkuById', '2016-11-18 11:44:46.977147', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('2c9d846101984f51888df3b304450611', null, null, '修改商品SKU', '\0', 'b8cdf103d2d94765b3daa148de8dc946', '20', '5', '/Admin/Shop/UpdateShopSku', '2016-11-19 00:41:24.944910', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('2ee41a90c3524069a6cc1e2d9dba1a42', 'btnSetNew', 'icon-cog', '设置为新功能', '\0', 'd42ce5046f48442a86052a946be18544', '3', '3', '/Admin/ButtonAction/NewWorn', '2016-10-11 10:58:04.693400', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('3234522eb8cc4cd7bd6e36c4ca5038a6', null, null, '订单查询', '\0', '5e2a6fc2c56e49c58ab1c6cc6984747d', '6', '4', '/Admin/Order/List', '2016-11-29 17:32:58.441490', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('3345919d971e421c9c264ef88f25b1af', 'btnStart', 'icon-unload', '启用', '\0', '4944bb424dd746be9622fb1327626419', '3', '3', '/Admin/Notice/Disable', '2016-11-28 15:50:41.617853', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('3f02d6a38b5142018750e76fac678259', 'btnStart', 'icon-unlock', '同意', '\0', '52aab839d4914211bd267af9f25bc9af', '1', '3', '/Admin/UserApply/Apply', '2016-12-10 13:27:02.576993', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('4274d378f27b46a5aa8277e55354a79d', null, null, '修改商品属性', '\0', 'b8cdf103d2d94765b3daa148de8dc946', '22', '5', '/Admin/Shop/UpdateShopAttr', '2016-11-19 02:15:38.293841', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('42f93db68ab1454a88339169b4c1f781', null, 'icon-money', '商城管理', '\0', '0', '2', '2', null, '2016-10-20 15:11:11.075142', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('4667a3b48a5d4102b6663e1f36439a13', null, null, '根据商品Id查询商品属性', '\0', 'b8cdf103d2d94765b3daa148de8dc946', '21', '5', '/Admin/Shop/GetShopAttr', '2016-11-19 00:42:13.662491', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('481effad103d4ea7a96e3548966129ab', 'btnSetRole', 'icon-cog', '配置角色', '\0', '2873856d56224b8db68b8ada1f1a0bca', '3', '3', '/Admin/User/UpdateSetRole', '2016-10-11 10:17:00.115516', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('4944bb424dd746be9622fb1327626419', null, 'icon-group', '通知公告', '', 'ca532a67f64745268314d222c0037c28', '2', '2', '/Admin/Notice/Index', '2016-11-26 00:08:29.405021', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('4e69234f3b81458fa216a83f8fce4eb9', 'btnForbidden', 'icon-lock', '禁用', '\0', 'd7f21a4a33444ceabdcaadbd4ea5771e', '5', '3', '/Admin/Role/Disable', '2016-10-11 10:52:28.086416', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('52aab839d4914211bd267af9f25bc9af', null, ' icon-plus-sign-alt', '入驻管理', '', 'ca532a67f64745268314d222c0037c28', '3', '2', '/Admin/UserApply/Index', '2016-12-10 13:23:57.610630', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('53b7b1e7cfe341f2a2f97667fc81c404', null, null, '获取留言类型', '\0', '142e445581c5452aa49b132a737bf8f4', '10', '5', '/Admin/Message/GetMessageTypeNameByMsgType', '2016-12-01 22:44:48.599136', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('549d4f5e80d64581b309fbc61bbdaad7', null, null, '商品评论查询', '\0', '5e2a6fc2c56e49c58ab1c6cc6984747d', '7', '4', '/Admin/Comment/List', '2016-11-29 14:40:05.461138', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('5867a33007354b08bca5b3c0018eb336', null, null, '根据商品Sku_Id查询商品价钱', '\0', '106ae703a29a4e9fbb4372ca3f101068', '11', '5', '/Admin/Order/ShopMoneyBySkuId', '2016-12-20 17:34:12.866831', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('58db1ac685894f528c43511504f21e7e', 'btnDelDialog', 'icon-remove', '删除', '\0', '142e445581c5452aa49b132a737bf8f4', '5', '3', '/Admin/Message/Delete', '2016-12-20 16:05:21.631673', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('59ee07e6edf240e1bbb7c6579755ba97', 'btnDetail', 'icon-book', '详情', '\0', 'd7f21a4a33444ceabdcaadbd4ea5771e', '6', '3', '/Admin/Role/GetById', '2016-10-11 10:53:18.710855', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('5c748957e92841e5b08fcd0729837962', null, null, '添加商品优惠', '\0', 'b8cdf103d2d94765b3daa148de8dc946', '25', '5', '/Admin/Shop/AddShopCoupon', '2016-11-21 15:24:49.375206', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('5e2a6fc2c56e49c58ab1c6cc6984747d', null, null, '查询权限(所有用户都拥有的权限)', '\0', '0', '10', '4', '/', '2016-10-10 17:53:23.780698', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('5f3426a5da90454bab66811ab1758800', 'btnDetail', 'icon-book', '详情', '\0', '9b1e5dfb54f847dba654c45a9edab27f', '5', '3', '/Admin/Department/GetById', '2016-10-11 10:12:13.973021', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('650ee2901c5340739c343302fd4e9896', 'btnStart', 'icon-unlock', '启用', '\0', '106ae703a29a4e9fbb4372ca3f101068', '3', '3', '/Admin/Order/Disable', '2016-11-29 18:06:07.070277', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('6702300594f0476cb405593728a422e2', 'btnStart', 'icon-unlock', '启用', '\0', '142e445581c5452aa49b132a737bf8f4', '3', '3', '/Admin/Message/Disable', '2016-11-25 20:27:37.532839', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('6853554841614c47aa2d658fba3999b8', null, null, '商品富文本上传图片', '\0', 'b8cdf103d2d94765b3daa148de8dc946', '10', '5', '/Admin/Shop/UploadEditor', '2016-11-17 12:45:55.800382', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('6d7e6b006b28466ab0ba5fab893c4af8', 'btnForbidden', 'icon-lock', '禁用', '\0', '1aaa477999b3491aa5318e598979d791', '3', '3', '/Admin/Comment/Disable', '2016-11-29 15:52:51.355756', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('6fb8d519ac8e495eb8abfe16f3f68def', 'btnForbidden', 'icon-lock', '禁用', '\0', '142e445581c5452aa49b132a737bf8f4', '4', '3', '/Admin/Message/Disable', '2016-11-25 20:28:19.053344', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('7226c42de5a44da0abff3f98753d48f6', null, 'icon-tag', 'Icon（图标）', '', 'ca532a67f64745268314d222c0037c28', '5', '2', '/Admin/Home/Icon', '2016-10-10 11:16:14.306138', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('74967d9fd19f4fababf8ceb4115eefa5', 'btnAddDepart', 'icon-plus', '添加', '\0', '9b1e5dfb54f847dba654c45a9edab27f', '1', '3', '/Admin/Department/Add', '2016-10-10 11:18:08.201742', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('7703959ccb1d4dfcac9805c01a8776cf', null, null, '角色查询', '\0', '5e2a6fc2c56e49c58ab1c6cc6984747d', '3', '4', '/Admin/Role/List', '2016-10-10 22:10:08.257851', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('77a8a00a4e8b4a5281b88c0c9e1290dc', null, null, '商品SKU删除', '\0', 'b8cdf103d2d94765b3daa148de8dc946', '11', '5', '/Admin/Shop/DeleteShopSku', '2016-11-17 17:52:25.020235', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('7b5248ff933746cfa6b8333e009e5fa3', null, null, '修改密码', '\0', 'faf9929ad1cb481b9402319ee8c8404b', '2', '5', '/Admin/Home/UpdatePassword', '2016-10-15 12:12:30.257921', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('7b88801431d2412da2a7c76f740784ca', null, null, '根据商品Id查询商品优惠', '\0', 'b8cdf103d2d94765b3daa148de8dc946', '24', '5', '/Admin/Shop/GetShopCouponById', '2016-11-21 15:24:11.149679', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('7bdcd5667d724ced8e37a0d8ca0d1fa7', 'btnDetail', 'icon-book', '详情', '\0', 'd42ce5046f48442a86052a946be18544', '7', '3', '/Admin/ButtonAction/GetActionById', '2016-10-11 11:00:05.506948', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('7c6a0030f3884d13b3935a6411cdcf44', null, null, '用户查询', '\0', '5e2a6fc2c56e49c58ab1c6cc6984747d', '2', '4', '/Admin/User/List', '2016-10-10 22:01:58.852385', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('7e4569671d0d42589564ee108521a54d', null, null, '商品SKU启用禁用', '\0', 'b8cdf103d2d94765b3daa148de8dc946', '19', '5', '/Admin/Shop/DisableShopSku', '2016-11-18 23:47:18.180551', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('7f438b52a4e94b24a989506c4452c11c', null, null, '用户读取临时权限', '\0', '2873856d56224b8db68b8ada1f1a0bca', '13', '5', '/Admin/ButtonAction/GetZtreeById', '2016-10-11 10:37:28.124946', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('81201a30135a4e468a2536ba72c19d33', 'btnDeleteDialog', 'icon-remove', '删除', '\0', '106ae703a29a4e9fbb4372ca3f101068', '5', '3', '/Admin/Order/Delete', '2016-12-19 23:35:00.249912', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('84324835a51844b1a99d5669a4471385', 'btnDetail', 'icon-book', '详情', '\0', '142e445581c5452aa49b132a737bf8f4', '6', '3', '/Admin/Message/GetById', '2016-11-25 22:05:23.982162', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('8466ead0f63948588bb39a6ba444655b', 'btnAddUser', 'icon-plus', '添加', '\0', '2873856d56224b8db68b8ada1f1a0bca', '1', '3', '/Admin/User/AddAdmin', '2016-10-11 10:15:02.407388', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('8821fdcf76ad4491b4c2b674fc5804c5', null, null, '公告查询', '\0', '5e2a6fc2c56e49c58ab1c6cc6984747d', '9', '4', '/Admin/Notice/List', '2016-11-28 22:52:10.031124', '0', '', null);
INSERT INTO `Pls_ButtonAction` VALUES ('88be3c8883b341cc98d6bfc24e0000e9', null, 'icon-home', '系统管理', '\0', '0', '1', '2', null, '2016-10-10 11:09:19.557695', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('8cce3b7a5d7046bfa69fd3ef231949a7', null, null, '商品图片删除', '\0', 'b8cdf103d2d94765b3daa148de8dc946', '15', '5', '/Admin/Shop/DeleteShopImage', '2016-11-18 14:28:14.144593', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('917b027a2b6a4f7ea93f8c8178744cb8', 'btnUpgradeOrderDialog', 'icon-leaf', '订单升级', '\0', '106ae703a29a4e9fbb4372ca3f101068', '2', '3', '/Admin/Order/UpgradeOrder', '2016-12-20 16:03:55.137613', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('9322be5e1aea4ceb8cfc5bdf7d094e04', 'btnDetail', 'icon-book', '详情', '\0', '1aaa477999b3491aa5318e598979d791', '4', '3', '/Admin/Comment/GetCommentById', '2016-11-29 15:53:45.571292', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('9b1e5dfb54f847dba654c45a9edab27f', null, 'icon-film', '部门管理', '', '88be3c8883b341cc98d6bfc24e0000e9', '2', '2', '/Admin/Department/Index', '2016-10-10 11:14:18.347778', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('9d08a3fc1afd4222b15d15cdbfe6068e', null, null, '退出用户', '\0', 'faf9929ad1cb481b9402319ee8c8404b', '3', '5', '/Admin/Home/Layout', '2016-10-11 11:55:38.163588', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('9d3496200b9e484d942806c3df5c9061', null, null, '订单查询商品SKu', '\0', '106ae703a29a4e9fbb4372ca3f101068', '10', '5', '/Admin/Order/ShopskuList', '2016-12-20 17:32:19.089599', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('9d40d9704eae428eb9f7d02c67aaad1e', 'btnPayDialog', ' icon-money', '支付', '\0', '106ae703a29a4e9fbb4372ca3f101068', '1', '3', '/Admin/Order/Pay', '2016-11-29 18:05:23.376742', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('9f1054dc4855448ba5adae687fc36c2d', null, null, '商品SKU添加', '\0', 'b8cdf103d2d94765b3daa148de8dc946', '11', '5', '/Admin/Shop/AddShopSku', '2016-11-17 14:32:57.655088', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('a0ea1781122c4dc987103897eb057bfa', 'btnForbidden', 'icon-lock', '不同意', '', '52aab839d4914211bd267af9f25bc9af', '2', '3', '/Admin/UserApply/Apply', '2016-12-10 13:28:03.345810', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('a1c314cee7784b5db03a96ed53f9da9f', null, null, '商品属性添加', '\0', 'b8cdf103d2d94765b3daa148de8dc946', '12', '5', '/Admin/Shop/AddShopAttr', '2016-11-17 15:55:54.302233', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('a3adc0ec364b436eb61e7efd6107e6d8', 'btnUpdateRead', 'icon-book', '标为已读', '\0', '142e445581c5452aa49b132a737bf8f4', '1', '3', '/Admin/Message/UpdateRead', '2016-11-19 11:58:54.611309', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('a41963a2c1fb4ed7b663afa1bca436fb', 'btnForbidden', 'icon-lock', '禁用', '\0', '9b1e5dfb54f847dba654c45a9edab27f', '4', '3', '/Admin/Department/Disable', '2016-10-11 10:11:05.581291', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('a64ce854a3484aa484a3b3aa1b6fd0a1', 'btnEditAction', 'icon-edit', '修改', '\0', 'd42ce5046f48442a86052a946be18544', '2', '3', '/Admin/ButtonAction/Update', '2016-10-11 10:57:33.869883', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('a6e73dbcd2aa4293b716ea314ffb9d17', null, null, '收入统计', '\0', 'faf9929ad1cb481b9402319ee8c8404b', '4', '5', '/Admin/Order/IncomeMoney', '2017-01-09 11:54:02.656746', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('a7e0aea5c03447488d1fcd0871090116', 'btnReply', ' icon-reply', '回复', '\0', '1aaa477999b3491aa5318e598979d791', '1', '3', '/Admin/Comment/Reply', '2016-11-29 15:51:01.464055', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('aadd89cbcc9543c4a50360d98be2a444', null, null, '角色读取权限', '\0', 'd7f21a4a33444ceabdcaadbd4ea5771e', '7', '5', '/Admin/ButtonAction/GetZtreeByRoleId', '2016-10-11 10:46:01.769346', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('ae1bd8b4e787406b931ccf267805282e', 'btnForbidden', 'icon-lock', '禁用', '\0', '2873856d56224b8db68b8ada1f1a0bca', '8', '3', '/Admin/User/Disable', '2016-10-11 10:40:28.947345', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('af1dd826561a4aff922593f62a1e101c', 'btnStart', 'icon-unlock', '启用', '\0', 'b8cdf103d2d94765b3daa148de8dc946', '4', '3', '/Admin/Shop/Disable', '2016-11-19 03:39:37.081136', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('b22cdad342de47bba9603278d8d06510', 'btnDeleteUserDialog', 'icon-remove', '删除', '\0', '2873856d56224b8db68b8ada1f1a0bca', '10', '3', '/Admin/User/Delete', '2016-10-20 10:47:24.578079', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('b2d927518d64420bb37739320d7abfa1', 'btnSetWorn', 'icon-cog', '设置为旧功能', '\0', 'd42ce5046f48442a86052a946be18544', '4', '3', '/Admin/ButtonAction/NewWorn', '2016-10-11 10:58:28.565850', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('b31abaa7726c476bbeaca6c5f9f9d2b3', 'btnDetail', 'icon-book', '详情', '\0', '2873856d56224b8db68b8ada1f1a0bca', '9', '3', '/Admin/User/getInnerById', '2016-10-11 10:41:27.290918', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('b3eba81c5cd944fbadea8e41f862f7ad', null, null, '用户配置临时权限查询/权限读取', '\0', '2873856d56224b8db68b8ada1f1a0bca', '15', '5', '/Admin/ButtonAction/GetZtree', '2016-10-10 22:04:59.338060', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('b4628aab2ebd4e9cba11f46d2d279137', 'btnDetail', 'icon-book', '详情', '\0', '52aab839d4914211bd267af9f25bc9af', '3', '3', '/Admin/UserApply/GetById', '2016-12-10 14:03:53.988265', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('b64ed45351844cbe8e8767ad33e54b39', null, null, '商品图片默认', '\0', 'b8cdf103d2d94765b3daa148de8dc946', '16', '5', '/Admin/Shop/DefaultShopImage', '2016-11-18 14:29:01.104530', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('b8cdf103d2d94765b3daa148de8dc946', null, 'icon-shopping-cart', '商品管理', '', '42f93db68ab1454a88339169b4c1f781', '1', '2', '/Admin/Shop/Index', '2016-11-15 19:28:18.401367', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('bc309c4fca36443493ee890a67e00be8', null, null, '留言查询', '\0', '5e2a6fc2c56e49c58ab1c6cc6984747d', '8', '4', '/Admin/Message/List', '2016-11-20 21:18:46.391267', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('bde2d3af663b426298a1fac1849885d1', null, null, '商品图片上传', '\0', 'b8cdf103d2d94765b3daa148de8dc946', '14', '5', '/Admin/Shop/UploadShopImage', '2016-11-18 11:45:32.309990', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('be6ae0c503c743679fa5c29529047e0e', 'btnActivate', 'icon-heart', '激活', '\0', '2873856d56224b8db68b8ada1f1a0bca', '5', '3', '/Admin/User/Activate', '2016-11-08 10:55:22.660870', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('c05a81d11c444b8bb58634e7878796f7', 'btnAddRole', 'icon-plus', '添加', '\0', 'd7f21a4a33444ceabdcaadbd4ea5771e', '1', '3', '/Admin/Role/Add', '2016-10-11 10:44:16.938992', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('c2aa8e08c1a740589d6dce1d1dc6a6a3', null, null, '根据商品Id查询商品SKU', '\0', 'b8cdf103d2d94765b3daa148de8dc946', '18', '5', '/Admin/Shop/GetShopSkuList', '2016-11-18 21:47:33.643237', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('ca532a67f64745268314d222c0037c28', null, 'icon-question-sign', '系统帮助', '\0', '0', '3', '2', null, '2016-10-10 11:10:20.300858', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('cba2f933bea340af9fdee2ea06f41cab', 'btnEditNotice', 'icon-edit', '修改', '\0', '4944bb424dd746be9622fb1327626419', '2', '3', '/Admin/Notice/Update', '2016-11-28 15:03:59.742028', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('cc98355a19034982bd5e0badca1493a2', 'btnAddAction', 'icon-plus', '添加', '\0', 'd42ce5046f48442a86052a946be18544', '1', '3', '/Admin/ButtonAction/Add', '2016-10-11 10:56:51.166883', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('ccb1ee2027c948d7b6e45e161502b724', null, null, '删除商品优惠', '\0', 'b8cdf103d2d94765b3daa148de8dc946', '27', '5', '/Admin/Shop/DeleteShopCoupon', '2016-11-21 15:25:35.541672', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('d01d984c744f4831ae5df45e87f355a6', 'btnEditShop', 'icon-edit', '修改', '\0', 'b8cdf103d2d94765b3daa148de8dc946', '2', '3', '/Admin/Shop/UpdateShop', '2016-11-18 16:43:55.058244', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('d42ce5046f48442a86052a946be18544', null, 'icon-lightbulb', '权限管理', '', '88be3c8883b341cc98d6bfc24e0000e9', '5', '2', '/Admin/ButtonAction/Index', '2016-10-10 11:15:31.745755', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('d456e73460384032b1d0908c6a364c81', 'btnEditRole', 'icon-edit', '修改', '\0', 'd7f21a4a33444ceabdcaadbd4ea5771e', '2', '3', '/Admin/Role/Update', '2016-10-11 10:44:58.441899', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('d682a6f9989148f59c004408ed4ebf56', null, null, '修改商品优惠', '\0', 'b8cdf103d2d94765b3daa148de8dc946', '26', '5', '/Admin/Shop/UpdateShopCoupon', '2016-11-21 15:25:09.797556', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('d7acc9c3b5c04d348fae6af11c13dfa7', 'btnEditUser', 'icon-edit', '修改', '\0', '2873856d56224b8db68b8ada1f1a0bca', '2', '3', '/Admin/User/UpdateAdmin', '2016-10-11 10:16:13.861027', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('d7f21a4a33444ceabdcaadbd4ea5771e', null, 'icon-group', '角色管理', '', '88be3c8883b341cc98d6bfc24e0000e9', '4', '2', '/Admin/Role/Index', '2016-10-10 11:15:07.252595', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('de350c71a64d447b88b9e12340a2fd32', null, null, '用户配置部门查询', '\0', '2873856d56224b8db68b8ada1f1a0bca', '16', '5', '/Admin/Department/listNoDisable', '2016-10-10 22:03:25.145774', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('e19539c404b7446c83a8483fb9e056e8', 'btnStart', 'icon-unlock', '启用', '\0', '1aaa477999b3491aa5318e598979d791', '2', '3', '/Admin/Comment/Disable', '2016-11-29 15:51:58.932190', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('e5fbe5a1511c4d4bad58bb97392083c5', 'btnForbidden', 'icon-lock', '禁用', '\0', '4944bb424dd746be9622fb1327626419', '4', '3', '/Admin/Notice/Disable', '2016-11-28 15:51:35.059606', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('ea61f10cf5324a88b7e5393ffbc0a4f8', 'btnForbidden', 'icon-lock', '禁用', '\0', 'd42ce5046f48442a86052a946be18544', '6', '3', '/Admin/ButtonAction/Disable', '2016-10-11 10:59:24.452516', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('ead05361323a46b38a9c12f534594889', 'btnForbidden', 'icon-lock', '禁用', '\0', 'b8cdf103d2d94765b3daa148de8dc946', '5', '3', '/Admin/Shop/Disable', '2016-11-19 03:40:22.663463', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('f4e2273ac1aa45ca9dd3bcd0b5f1e8c7', 'btnSetAction', 'icon-cogs', '配置临时权限', '\0', '2873856d56224b8db68b8ada1f1a0bca', '4', '3', '/Admin/ButtonAction/AddUserAction', '2016-10-11 10:39:15.581275', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('f7d003f12ec94d14a99e3268e09eef12', 'btnSetAction', 'icon-cogs', '配置权限', '\0', 'd7f21a4a33444ceabdcaadbd4ea5771e', '3', '3', '/Admin/ButtonAction/AddRoleAction', '2016-10-11 10:50:22.607398', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('fa02e2480d274713b53785789eab317b', 'btnSetResolve', ' icon-fighter-jet', '设置已解决', '\0', '142e445581c5452aa49b132a737bf8f4', '2', '3', '/Admin/Message/SetResolve', '2016-11-20 22:20:16.911250', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('faa8b76db3ec4bd8a334288eded5190d', null, null, '用户配置角色查询', '\0', '2873856d56224b8db68b8ada1f1a0bca', '17', '5', '/Admin/Role/listNoDisable', '2016-10-10 22:04:20.262597', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('faf9929ad1cb481b9402319ee8c8404b', null, 'icon-comment', '首页', '', '88be3c8883b341cc98d6bfc24e0000e9', '1', '2', '/Admin/Home/Index', '2016-10-10 11:13:43.868483', '0', null, null);
INSERT INTO `Pls_ButtonAction` VALUES ('fd214e7cb77f4c81a3731e6a7c6b3842', 'btnStart', 'icon-unlock', '启用', '\0', 'd7f21a4a33444ceabdcaadbd4ea5771e', '4', '3', '/Admin/Role/Disable', '2016-10-11 10:51:44.978722', '0', null, null);

-- ----------------------------
-- Table structure for Pls_Carousel
-- ----------------------------
DROP TABLE IF EXISTS `Pls_Carousel`;
CREATE TABLE `Pls_Carousel` (
  `carousel_id` varchar(127) NOT NULL,
  `carousel_conent` varchar(100) NOT NULL,
  `carousel_href` varchar(100) DEFAULT NULL,
  `carousel_image` varchar(255) NOT NULL,
  `carousel_sort` int(11) NOT NULL DEFAULT '1',
  `carousel_titie` varchar(40) NOT NULL,
  `createtime` datetime(6) NOT NULL,
  `disable` int(11) NOT NULL DEFAULT '0',
  `disabledesc` longtext,
  `row_number` longblob,
  PRIMARY KEY (`carousel_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of Pls_Carousel
-- ----------------------------

-- ----------------------------
-- Table structure for Pls_Comment
-- ----------------------------
DROP TABLE IF EXISTS `Pls_Comment`;
CREATE TABLE `Pls_Comment` (
  `comment_id` varchar(127) NOT NULL,
  `comment_desc` longtext,
  `comment_reply` longtext,
  `comment_star` int(11) NOT NULL DEFAULT '5',
  `createtime` datetime(6) NOT NULL,
  `disable` int(11) NOT NULL DEFAULT '0',
  `disabledesc` longtext,
  `parant_userid` longtext NOT NULL,
  `row_number` longblob,
  `user_id` varchar(64) NOT NULL,
  `shop_id` varchar(64) NOT NULL DEFAULT '',
  `shopsku_id` varchar(64) NOT NULL DEFAULT '',
  PRIMARY KEY (`comment_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of Pls_Comment
-- ----------------------------

-- ----------------------------
-- Table structure for Pls_CommentImage
-- ----------------------------
DROP TABLE IF EXISTS `Pls_CommentImage`;
CREATE TABLE `Pls_CommentImage` (
  `commentiamge_id` varchar(127) NOT NULL,
  `comment_address` varchar(200) DEFAULT NULL,
  `comment_id` varchar(64) NOT NULL,
  `row_number` longblob,
  PRIMARY KEY (`commentiamge_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of Pls_CommentImage
-- ----------------------------

-- ----------------------------
-- Table structure for Pls_Department
-- ----------------------------
DROP TABLE IF EXISTS `Pls_Department`;
CREATE TABLE `Pls_Department` (
  `department_id` varchar(127) NOT NULL,
  `createtime` datetime(6) NOT NULL,
  `department_desc` longtext,
  `department_name` varchar(128) NOT NULL,
  `disable` int(11) NOT NULL DEFAULT '0',
  `disabledesc` longtext,
  `row_number` longblob,
  PRIMARY KEY (`department_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of Pls_Department
-- ----------------------------
INSERT INTO `Pls_Department` VALUES ('5124892ffa16455d907b2cc4ebcb966a', '2016-10-15 20:51:49.325606', '负责前台业务以及JS等实现(陈缘萍)', '初心团队前端组', '0', null, null);
INSERT INTO `Pls_Department` VALUES ('a104c92016664a929ff589d610482c2d', '2016-10-11 15:35:41.437730', '负责公司所有产品的测试等工作', '初心团队测试组', '0', null, null);
INSERT INTO `Pls_Department` VALUES ('f5f8040c0b7d494a848a20c623c11565', '2016-10-10 10:58:48.586836', '初心系统高级部门(人员：韩迎龙、波波、尚伟伟)', '初心团队后端研发师', '0', '', null);

-- ----------------------------
-- Table structure for Pls_Message
-- ----------------------------
DROP TABLE IF EXISTS `Pls_Message`;
CREATE TABLE `Pls_Message` (
  `message_id` varchar(127) NOT NULL,
  `createtime` datetime(6) NOT NULL,
  `disable` int(11) NOT NULL DEFAULT '0',
  `disabledesc` longtext,
  `message_desc` longtext,
  `message_read` int(11) NOT NULL DEFAULT '1',
  `message_solve` int(11) NOT NULL DEFAULT '1',
  `message_type` int(11) NOT NULL DEFAULT '1',
  `row_number` longblob,
  `user_id` varchar(64) DEFAULT NULL,
  PRIMARY KEY (`message_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of Pls_Message
-- ----------------------------
INSERT INTO `Pls_Message` VALUES ('24104211871e48d894c7941ad24a1b9c', '2016-12-16 20:49:49.765999', '0', null, '尺寸上对应在调试吧，自适应有待改进', '0', '0', '1', null, '');
INSERT INTO `Pls_Message` VALUES ('3ec5b3c04eeb4386bedf007ce888b178', '2017-03-06 09:50:02.360859', '0', null, '大神： 您有录制视频不', '0', '0', '1', null, 'cc64df824a6747e09ceb4aa926fed05a');
INSERT INTO `Pls_Message` VALUES ('4a9b9f2675994665b1b637cb3be87e82', '2017-01-22 15:00:01.616649', '0', null, '很好的网站，支持你，希望你做的越来越好~~~~', '0', '0', '1', null, '');
INSERT INTO `Pls_Message` VALUES ('89e4a0f81bf54aa29bbfd7bebc87c2bd', '2017-03-13 10:18:19.664076', '0', null, '请问redis使用了那个', '0', '1', '1', null, '');
INSERT INTO `Pls_Message` VALUES ('9c75c8121e1040f3a5163cef0446d81f', '2017-02-13 11:57:32.742494', '0', null, 'web化小出现两个导航栏', '0', '1', '1', null, '');
INSERT INTO `Pls_Message` VALUES ('a320840114b14358be9ecdda283d284d', '2017-02-02 21:11:56.818977', '0', null, '支持，支持~~，希望你做的越来越好,asp.net core果然强大，加油', '0', '0', '1', null, '');
INSERT INTO `Pls_Message` VALUES ('d7ad37d929d34a5fa79921563ba3a93c', '2017-03-13 12:56:46.880817', '0', null, '这个关于我们的功能好像没做完吧，直接提示404了', '0', '1', '1', null, '');
INSERT INTO `Pls_Message` VALUES ('e3c78f4f77414574ac8c2d765bb827a8', '2017-01-29 22:22:07.021175', '0', null, '大过年的时候看到了这里，很不错，加油⛽️，支持你群主', '0', '0', '1', null, '');

-- ----------------------------
-- Table structure for Pls_Notice
-- ----------------------------
DROP TABLE IF EXISTS `Pls_Notice`;
CREATE TABLE `Pls_Notice` (
  `notice_id` varchar(127) NOT NULL,
  `createtime` datetime(6) NOT NULL,
  `disable` int(11) NOT NULL DEFAULT '0',
  `disabledesc` longtext,
  `notice_desc` varchar(100) DEFAULT NULL,
  `row_number` longblob,
  PRIMARY KEY (`notice_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of Pls_Notice
-- ----------------------------
INSERT INTO `Pls_Notice` VALUES ('17029a857a274a1ba4523406ebc8991d', '2016-10-23 10:11:51.394644', '0', null, '初心信息系统V1.0.0版上线(后台权限管理、前台静态页等部门内容上线(测试上线，功能不够完善))！', null);
INSERT INTO `Pls_Notice` VALUES ('20143b842f52493e941bc00853632f57', '2016-09-01 10:12:22.736540', '0', null, '初心信息系统准备开发、组建团队并且申请域名(http://www.chuxinm.com)(http://www.chuxinm.cn)和服务器', null);
INSERT INTO `Pls_Notice` VALUES ('3eda3498a34d401f8b72bf5f792b4387', '2016-10-10 10:12:05.065868', '0', null, '初心信息系统后台权限管理完成并且部署阿里云完成试上线，收到一些网友的反馈，谢谢大家！', null);
INSERT INTO `Pls_Notice` VALUES ('771fcef6572d4cb4a4bb1f97d8b60e40', '2016-09-15 10:12:13.496685', '0', null, '初心团队初步组建完成，成员包括研发(韩迎龙/彭成波/尚伟伟)、前端设计(陈缘萍)、测试(卢俊涛)', null);
INSERT INTO `Pls_Notice` VALUES ('8d5713698051402d92e146e4c86fed1b', '2016-12-16 14:48:59.347832', '0', null, '历时三个半月，系统在今天这个难忘的日子里面正式投入使用，访问域名：http://www.chuxinm.com', null);
INSERT INTO `Pls_Notice` VALUES ('c579a5d45a8043ca846d4c4d9babd115', '2016-12-12 13:04:58.655965', '0', null, '初心系统V2.0.0系统历时3个半月，从9月1号开启至今，提交测试，欢迎大家对系统进行测试并提出你们宝贵的意见，谢谢', null);
INSERT INTO `Pls_Notice` VALUES ('c8faefc78cf342949346e571861288bb', '2017-02-13 13:31:57.813184', '0', null, '年后工作暂停，本网站急找前端和设计的合作者，如果谁感兴趣，可以加我QQ:934532778我们详谈一下，诚心期待能和未来的你合作！', null);
INSERT INTO `Pls_Notice` VALUES ('f3596bbe3cbd475990ed82dd1ae2e2f4', '2017-01-03 15:31:27.163060', '0', null, '系统架构使用redis进行缓存信息。使用七牛云对网站中所有的图片进行存放读取~', null);

-- ----------------------------
-- Table structure for Pls_Order
-- ----------------------------
DROP TABLE IF EXISTS `Pls_Order`;
CREATE TABLE `Pls_Order` (
  `order_id` varchar(127) NOT NULL,
  `createtime` datetime(6) NOT NULL,
  `disable` int(11) NOT NULL DEFAULT '0',
  `disabledesc` longtext,
  `order_actualpay` double NOT NULL,
  `order_delete` int(11) NOT NULL DEFAULT '1',
  `order_goods` int(11) NOT NULL DEFAULT '1',
  `order_memo` varchar(200) DEFAULT NULL,
  `order_number` varchar(32) NOT NULL,
  `order_paystatus` int(11) NOT NULL DEFAULT '1',
  `order_privilege` double NOT NULL,
  `order_total` double NOT NULL,
  `row_number` longblob,
  `user_id` varchar(64) NOT NULL,
  `order_payway` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`order_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of Pls_Order
-- ----------------------------

-- ----------------------------
-- Table structure for Pls_OrderDetail
-- ----------------------------
DROP TABLE IF EXISTS `Pls_OrderDetail`;
CREATE TABLE `Pls_OrderDetail` (
  `orderdetail_id` varchar(127) NOT NULL,
  `order_id` longtext,
  `row_number` longblob,
  `shop_currentprice` double NOT NULL,
  `shop_id` varchar(64) NOT NULL,
  `shopcoupon_id` varchar(64) NOT NULL DEFAULT '0',
  `shopsku_id` varchar(64) NOT NULL,
  `shop_count` int(11) NOT NULL DEFAULT '1',
  `orderdetail_delete` int(11) NOT NULL DEFAULT '1',
  `orderdetail_evaluate` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`orderdetail_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of Pls_OrderDetail
-- ----------------------------

-- ----------------------------
-- Table structure for Pls_Role
-- ----------------------------
DROP TABLE IF EXISTS `Pls_Role`;
CREATE TABLE `Pls_Role` (
  `role_id` varchar(127) NOT NULL,
  `createtime` datetime(6) NOT NULL,
  `disable` int(11) NOT NULL DEFAULT '0',
  `disabledesc` longtext,
  `role_desc` longtext,
  `role_name` varchar(64) NOT NULL,
  `role_type` int(11) NOT NULL DEFAULT '2',
  `row_number` longblob,
  PRIMARY KEY (`role_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of Pls_Role
-- ----------------------------
INSERT INTO `Pls_Role` VALUES ('48acf9ec7e714966a198750303af39c1', '2016-10-11 11:02:59.033321', '0', null, '入驻商户管理(对入驻的商户信息进行管理的权限)', '入驻商户权限', '2', null);
INSERT INTO `Pls_Role` VALUES ('675d1215b42d423995f82f3abf48818c', '2016-10-10 11:05:39.972141', '0', null, '拥有所有超级管理员权限，不可删除', '超级管理员', '2', null);
INSERT INTO `Pls_Role` VALUES ('f54be3bd06bc4b2798d823b933538cb6', '2016-10-10 11:06:21.157437', '0', null, '前端在注册的时候，默认必须配置的权限', '注册默认权限', '1', null);

-- ----------------------------
-- Table structure for Pls_Role_ButtonAction
-- ----------------------------
DROP TABLE IF EXISTS `Pls_Role_ButtonAction`;
CREATE TABLE `Pls_Role_ButtonAction` (
  `rolebutton_id` varchar(127) NOT NULL,
  `action_id` varchar(64) NOT NULL,
  `role_id` varchar(64) NOT NULL,
  `row_number` longblob,
  PRIMARY KEY (`rolebutton_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of Pls_Role_ButtonAction
-- ----------------------------
INSERT INTO `Pls_Role_ButtonAction` VALUES ('013c46499f7c4d1b8f183c4e9264bc85', 'ca532a67f64745268314d222c0037c28', '48acf9ec7e714966a198750303af39c1', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('0278356812974ba2ae4b3a83b9c129c9', '10f146052fcb4c19be6d6fc30f10faef', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('04628f137ea449d4aa96d17f2377985d', '5867a33007354b08bca5b3c0018eb336', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('051cd6ceb500444bb79a813d82511e7f', 'aadd89cbcc9543c4a50360d98be2a444', 'f54be3bd06bc4b2798d823b933538cb6', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('053f4968aa934c99b0a8161f4cdc3f72', '549d4f5e80d64581b309fbc61bbdaad7', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('06dc907079fc4f38b7552ba60119b5d7', '9f1054dc4855448ba5adae687fc36c2d', '48acf9ec7e714966a198750303af39c1', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('0967c1b45b434d2ca228a3860a5fe1bf', '23df0b86927c498a90af9fa9eb306b5d', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('09d02a4d338149df894b145f0d467864', '52aab839d4914211bd267af9f25bc9af', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('0a6434eb6f55470e84494bab5fae9066', '58db1ac685894f528c43511504f21e7e', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('0aec69a449da49edab9b707b4e2ff7b2', '4e69234f3b81458fa216a83f8fce4eb9', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('0b923ff38fea482b9cd3878491e4dfc8', '77a8a00a4e8b4a5281b88c0c9e1290dc', '48acf9ec7e714966a198750303af39c1', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('0c013d364173466d82b4f446f68e48d0', 'd42ce5046f48442a86052a946be18544', 'f54be3bd06bc4b2798d823b933538cb6', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('0c8a0b17f8bf482cb5e39ef83533ad1c', 'c05a81d11c444b8bb58634e7878796f7', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('0d8e99df528d4107935fc2a3ba999f5f', '6853554841614c47aa2d658fba3999b8', '48acf9ec7e714966a198750303af39c1', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('1140fb253e0b41e8a0337fcf73d01f0b', '9322be5e1aea4ceb8cfc5bdf7d094e04', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('13858d1c25a8442ab8276528872222af', '4944bb424dd746be9622fb1327626419', 'f54be3bd06bc4b2798d823b933538cb6', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('1415df3ca275465a848e4620c9caf857', 'bc309c4fca36443493ee890a67e00be8', 'f54be3bd06bc4b2798d823b933538cb6', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('15725ee3e207471b89cefa7690f1a02a', '7c6a0030f3884d13b3935a6411cdcf44', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('1585c96d888644dfbb2c4e95fa4ec86b', 'a6e73dbcd2aa4293b716ea314ffb9d17', 'f54be3bd06bc4b2798d823b933538cb6', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('15ffdadec9e0458cb5d598547e4aa679', '7bdcd5667d724ced8e37a0d8ca0d1fa7', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('1633e6e9f9604ae19cecebced9f69c1b', '5e2a6fc2c56e49c58ab1c6cc6984747d', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('17b0a889502042f69f51bb540d6dd486', 'faa8b76db3ec4bd8a334288eded5190d', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('1862c6928de843fb9c64d02333cedf31', 'b31abaa7726c476bbeaca6c5f9f9d2b3', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('1950f0e0da9c49e8b099ef972cbf5bfb', '7e4569671d0d42589564ee108521a54d', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('1a09104409b842d99cd1568af95684b4', '7226c42de5a44da0abff3f98753d48f6', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('1b65cbdc1c2343bc900fcdf650e828ab', 'd682a6f9989148f59c004408ed4ebf56', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('1c95f03cd4a34665b3a6026a381817ad', '0d0786209da3427c9b285ad67add1366', '48acf9ec7e714966a198750303af39c1', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('1cde023a5e2d41bfb5ad3952f9c607f6', '4667a3b48a5d4102b6663e1f36439a13', '48acf9ec7e714966a198750303af39c1', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('1d84f0ac8b0046eea649729a4c9bbdfb', 'af1dd826561a4aff922593f62a1e101c', '48acf9ec7e714966a198750303af39c1', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('1ded9bebe18b4f969ca29d2d70bc3e44', '4274d378f27b46a5aa8277e55354a79d', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('1edefdcb91154fdf974209ff64da445a', 'd682a6f9989148f59c004408ed4ebf56', '48acf9ec7e714966a198750303af39c1', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('1eff6ab1c53c49618c3483f18b7d0795', 'a41963a2c1fb4ed7b663afa1bca436fb', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('20a7cc03233144038d9b34d52d5fa106', '7e4569671d0d42589564ee108521a54d', '48acf9ec7e714966a198750303af39c1', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('21a4bf8941834987a0f4554184ce27cd', '7f438b52a4e94b24a989506c4452c11c', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('21a67eb418c94214bc72416f6a53b71e', '8cce3b7a5d7046bfa69fd3ef231949a7', '48acf9ec7e714966a198750303af39c1', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('21b16c384455491d8446580bdb52a422', '4944bb424dd746be9622fb1327626419', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('22a21d6803444111a144406771ecfbee', 'ccb1ee2027c948d7b6e45e161502b724', '48acf9ec7e714966a198750303af39c1', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('263623126d8a41a8a50fad9d957c1954', '0f358ad7be134f909ac467f8cc14475c', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('2768a6356b2341b799c881170520d6d4', '81201a30135a4e468a2536ba72c19d33', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('28aba62de503472eb0e05fd866bb2a19', '84324835a51844b1a99d5669a4471385', 'f54be3bd06bc4b2798d823b933538cb6', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('2a3c002caf7d4ce9ab315c429a7ae3c1', 'f4e2273ac1aa45ca9dd3bcd0b5f1e8c7', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('2ac24cb40bbb491e931b6493f7d84cc4', '1f3b9338b2f84e9f9e9bd6587b9cf3fd', 'f54be3bd06bc4b2798d823b933538cb6', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('2c0658f790ee4725ba60e0642ee7e58d', '1f3b9338b2f84e9f9e9bd6587b9cf3fd', '48acf9ec7e714966a198750303af39c1', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('2d39cee3840e4c58ad7caf43363b21d5', '15c786f0db5d460fabbbc807ce237393', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('30a4d0bb811d49af8a1fb66facc4c62e', 'ca532a67f64745268314d222c0037c28', 'f54be3bd06bc4b2798d823b933538cb6', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('30ed99480c67423cbcafaaa48fa43434', '7b5248ff933746cfa6b8333e009e5fa3', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('31f714ddb9ba4a2ea48c79443b123a23', '8821fdcf76ad4491b4c2b674fc5804c5', '48acf9ec7e714966a198750303af39c1', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('328dfca0034b4036bf436f7d0f5cc6d9', '4667a3b48a5d4102b6663e1f36439a13', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('359e5adc16694f7496a74f494840bbed', '42f93db68ab1454a88339169b4c1f781', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('3611038eafc04d39b2fc7b6df90e3d3d', '2c9d846101984f51888df3b304450611', '48acf9ec7e714966a198750303af39c1', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('37af4f59dbc5430d811dc6acc8665e77', 'e5fbe5a1511c4d4bad58bb97392083c5', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('39c46bf479a345b38b7b1f8cae0c039e', 'a7e0aea5c03447488d1fcd0871090116', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('3b3a9437bcd5416aad0643cfe3c5e278', 'bc309c4fca36443493ee890a67e00be8', '48acf9ec7e714966a198750303af39c1', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('3b84097f1a8649f69ea817d261f8aa6b', 'b4628aab2ebd4e9cba11f46d2d279137', 'f54be3bd06bc4b2798d823b933538cb6', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('3d17f5eb5beb43758316ca4410621878', '1020ee13119946bba16442b624c2c3ba', 'f54be3bd06bc4b2798d823b933538cb6', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('413602470c564657b41b6322e5a6229b', 'b3eba81c5cd944fbadea8e41f862f7ad', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('414cd31842314766860f0acb673089eb', '1aad6290cc2d41b5b078794546558b47', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('416b22fbf1eb4041bc5061716db5310d', '88be3c8883b341cc98d6bfc24e0000e9', '48acf9ec7e714966a198750303af39c1', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('41ce8562084a47768b1f67711140a1f5', '23b1c26eeefe4d2f8cbb9f6c6cddec44', 'f54be3bd06bc4b2798d823b933538cb6', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('438d0338cc0549d98d9c58732f14c59e', '3f02d6a38b5142018750e76fac678259', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('45bfc724c17c458993a352de223fe862', '0d0786209da3427c9b285ad67add1366', 'f54be3bd06bc4b2798d823b933538cb6', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('46777c4d188046cc8d2d38c24a28c313', '183e0bb7e7cc44eda5272ccca960e227', 'f54be3bd06bc4b2798d823b933538cb6', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('46831f7130c14d02848d4d1d67ac5c91', 'de350c71a64d447b88b9e12340a2fd32', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('46baa43a719447fcafdf8807d821ecbe', '9f1054dc4855448ba5adae687fc36c2d', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('4a0c611221364d2a8d53e0463202bd93', '84324835a51844b1a99d5669a4471385', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('4a5accfc85974dfa88225a9574780886', '1f2b2c30c45b4bf0ab8691cf1e778b2c', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('4c2713af48944fbdbd187962c8136f99', 'faf9929ad1cb481b9402319ee8c8404b', '48acf9ec7e714966a198750303af39c1', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('4d3528ff3b9d4e79a20f9e56ee82f320', '8821fdcf76ad4491b4c2b674fc5804c5', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('4de3566b8a014bae97cafe201aae762f', '9d08a3fc1afd4222b15d15cdbfe6068e', 'f54be3bd06bc4b2798d823b933538cb6', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('4e281d0aff704097bebc01920f220689', '9b1e5dfb54f847dba654c45a9edab27f', 'f54be3bd06bc4b2798d823b933538cb6', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('50a8119e13ab49d4bf3d8eedbccb874b', 'c2aa8e08c1a740589d6dce1d1dc6a6a3', '48acf9ec7e714966a198750303af39c1', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('50a9cb2420b448e6b3b637407307909f', 'aadd89cbcc9543c4a50360d98be2a444', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('548f8dc22b4b492d905331191240d50d', 'faf9929ad1cb481b9402319ee8c8404b', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('55e4deb0f80a4bf2a6b2502955352bf4', '7b88801431d2412da2a7c76f740784ca', '48acf9ec7e714966a198750303af39c1', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('55ec70a314434cd4af9c73a447ea70b5', '74967d9fd19f4fababf8ceb4115eefa5', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('58af3a554546477abfe10da76cd8145f', '2ee41a90c3524069a6cc1e2d9dba1a42', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('5a6db8dc4c874094896ac04ee0cdd693', 'd7f21a4a33444ceabdcaadbd4ea5771e', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('5a95b918bc7b467eb6a35e5e981b2470', '7226c42de5a44da0abff3f98753d48f6', '48acf9ec7e714966a198750303af39c1', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('5be49a9945b642ef91943bb131200701', 'd7f21a4a33444ceabdcaadbd4ea5771e', 'f54be3bd06bc4b2798d823b933538cb6', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('5fe34a4c2ffe460bb571308eb9a621c3', '0c8967bc8411440d8eb21b77bfa97ebb', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('60a7120374ad4184b04a36bcb21053e4', 'fa02e2480d274713b53785789eab317b', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('61cad68e5070487d9d993964cb4881f6', 'fd214e7cb77f4c81a3731e6a7c6b3842', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('63aeffc53b4a4b3d91fc990c0d183e30', '3234522eb8cc4cd7bd6e36c4ca5038a6', 'f54be3bd06bc4b2798d823b933538cb6', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('63e8dc1c447d47bc88d107cc65271c46', '7bdcd5667d724ced8e37a0d8ca0d1fa7', 'f54be3bd06bc4b2798d823b933538cb6', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('65226af421ac47c9ae84be2e998f3572', '9322be5e1aea4ceb8cfc5bdf7d094e04', 'f54be3bd06bc4b2798d823b933538cb6', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('671c39fef54d482a8902a70603650948', '15748e54f0c74c48aba5dbfba70de04a', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('696c27aa9e6147ebbe479d8e66e7ffe6', '59ee07e6edf240e1bbb7c6579755ba97', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('699ddf8bb3a64010945ff4502a602dd3', '15c786f0db5d460fabbbc807ce237393', '48acf9ec7e714966a198750303af39c1', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('6acbcd6d326d4b71846c726301460b73', '23b1c26eeefe4d2f8cbb9f6c6cddec44', '48acf9ec7e714966a198750303af39c1', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('6d3c83b110754556b05d8aaeaa113593', '3345919d971e421c9c264ef88f25b1af', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('6d8c69eb61f043a5bbbee438b8f3b55e', 'a1c314cee7784b5db03a96ed53f9da9f', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('7272be91e0434992b71686adf623eb96', '7b5248ff933746cfa6b8333e009e5fa3', '48acf9ec7e714966a198750303af39c1', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('7443c7ea79b240a6aa6e04031a5bbf49', '9d40d9704eae428eb9f7d02c67aaad1e', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('74e471bc6710461daae41d7f9375c1da', '5f3426a5da90454bab66811ab1758800', 'f54be3bd06bc4b2798d823b933538cb6', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('7759dc0a01ed4f41a105ad8b32fefbe9', 'af1dd826561a4aff922593f62a1e101c', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('79b5154917494aea8d9a8229b81ed7cb', '8cce3b7a5d7046bfa69fd3ef231949a7', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('7a42f7d971594d9f9b3719eaeb2bfc93', '9b1e5dfb54f847dba654c45a9edab27f', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('7c520eea63dc4dde8722d8ae7c7f98ed', 'a6e73dbcd2aa4293b716ea314ffb9d17', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('7e21c719f66f468598980adf6d7da8da', '42f93db68ab1454a88339169b4c1f781', '48acf9ec7e714966a198750303af39c1', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('804cfde39a5743acb7eefd58483350ca', '2873856d56224b8db68b8ada1f1a0bca', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('830049b069164750b72ced560062306b', '6d7e6b006b28466ab0ba5fab893c4af8', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('84467f94a4934a2281def38754f63752', '549d4f5e80d64581b309fbc61bbdaad7', '48acf9ec7e714966a198750303af39c1', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('847ace8b186645d8b875513634cacdf3', '5f3426a5da90454bab66811ab1758800', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('84a02ba128074abeaa1aeac024b7256d', 'f7d003f12ec94d14a99e3268e09eef12', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('8749a69e4a744667bb41f97c79e06b28', '15869529e4b54322b764b1ad196d15f8', '48acf9ec7e714966a198750303af39c1', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('89b3888755d8423ca9672f55bba11c0b', '2c5ed44f8d8a4e67a328e80eb71b78ed', '48acf9ec7e714966a198750303af39c1', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('8ad71b19fc784a6aa91d6323293c78f5', '7226c42de5a44da0abff3f98753d48f6', 'f54be3bd06bc4b2798d823b933538cb6', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('8e2b1860e0d440329c0e460e8b8f1a5b', 'faf9929ad1cb481b9402319ee8c8404b', 'f54be3bd06bc4b2798d823b933538cb6', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('8e8caf63a13a40f88933ba9a4dc0549e', 'ea61f10cf5324a88b7e5393ffbc0a4f8', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('8f7dd80bb8c444c3ab0c73f00d9b7269', '7703959ccb1d4dfcac9805c01a8776cf', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('9189c6239c4b48ef888523ddde8b1a3e', 'd01d984c744f4831ae5df45e87f355a6', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('95e10e8680504701aba01065b5152751', '0f358ad7be134f909ac467f8cc14475c', '48acf9ec7e714966a198750303af39c1', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('969a88e1f8004475ab1b1065aa5a9df8', 'd456e73460384032b1d0908c6a364c81', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('96f4934715424971ae6197eade601461', '0c3d3b6c1fd848e0bd3c0af660f36f41', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('97629704b64841549f9414ab25743874', '1aaa477999b3491aa5318e598979d791', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('9945867e78a544b4a88796dbd5a68ace', '2c5ed44f8d8a4e67a328e80eb71b78ed', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('995c4477f3ee4ca49b286df5e0ec4fe5', '15748e54f0c74c48aba5dbfba70de04a', '48acf9ec7e714966a198750303af39c1', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('99940941b8e646a1ac39714a0f144d97', 'bde2d3af663b426298a1fac1849885d1', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('99df918ef5754394ae9ed56b27066cea', 'b2d927518d64420bb37739320d7abfa1', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('9b8134f97339496f8671e759d3942cfa', 'c2aa8e08c1a740589d6dce1d1dc6a6a3', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('9c09ebbc57c6451898a00b1ea7fb037f', '159b60bd57cd462c89349c109ab32d85', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('9f3ef773cbf04e3f9d19d0eabdb74d32', '07e2b180c3b24a98992c4b95017d72fe', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('a3f0494bb4734561869f2e6e1fa4096e', '10f146052fcb4c19be6d6fc30f10faef', '48acf9ec7e714966a198750303af39c1', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('a503f1124db740c990619b12005c91cb', '7c6a0030f3884d13b3935a6411cdcf44', 'f54be3bd06bc4b2798d823b933538cb6', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('a549f350c2ad42bd8cda58d7223c4ee2', '1aaa477999b3491aa5318e598979d791', 'f54be3bd06bc4b2798d823b933538cb6', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('a61da6bdd6134432b37b189e2814c638', '8466ead0f63948588bb39a6ba444655b', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('a804145d8e564d1e8d1f76d5bd2515b8', 'b64ed45351844cbe8e8767ad33e54b39', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('a88be72d5a174382b74956c924937fb3', '6853554841614c47aa2d658fba3999b8', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('aea51f18ad1a420babab31f87befbb74', '88be3c8883b341cc98d6bfc24e0000e9', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('af25a238b8a44af5a894e3fe6bc4a70b', '5c748957e92841e5b08fcd0729837962', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('b3bd84bdd1584b01b3832faeca28f8b7', 'b8cdf103d2d94765b3daa148de8dc946', 'f54be3bd06bc4b2798d823b933538cb6', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('b5d7127f56134ae6ab7068c51e5bc9bc', '142e445581c5452aa49b132a737bf8f4', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('b5dc8d30160143cc95b6fd02fb2b8015', '52aab839d4914211bd267af9f25bc9af', 'f54be3bd06bc4b2798d823b933538cb6', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('b624656dfac24eba80873fc9a87a637c', '53b7b1e7cfe341f2a2f97667fc81c404', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('b994c70031a8401db35f9467a9117a50', 'bde2d3af663b426298a1fac1849885d1', '48acf9ec7e714966a198750303af39c1', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('bd2dd36d7a6846c18a41e9095271ceac', 'a0ea1781122c4dc987103897eb057bfa', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('bdb4c539f9a645daa9cbfa15ed3ac1c6', '7703959ccb1d4dfcac9805c01a8776cf', 'f54be3bd06bc4b2798d823b933538cb6', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('be2eba085fbe4307ade018ea52d8cb41', '3234522eb8cc4cd7bd6e36c4ca5038a6', '48acf9ec7e714966a198750303af39c1', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('c269f82705304f91ae986655b688b89d', '10f146052fcb4c19be6d6fc30f10faef', 'f54be3bd06bc4b2798d823b933538cb6', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('c2b22eedd15d4f528fb2d10b780ff05b', '5e2a6fc2c56e49c58ab1c6cc6984747d', '48acf9ec7e714966a198750303af39c1', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('c3b06394315845dba0fb1ba99dd037e7', 'd01d984c744f4831ae5df45e87f355a6', '48acf9ec7e714966a198750303af39c1', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('c3b9296a38f6427695323aa63d61eb1e', '77a8a00a4e8b4a5281b88c0c9e1290dc', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('c6dfc02d7c8c4e7e8abbbb714edbdb4c', '650ee2901c5340739c343302fd4e9896', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('c832584f039743f6b638a2ebfe5ba458', '2c9d846101984f51888df3b304450611', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('c87962a55a9942db82d135f1e4de9f85', 'ca532a67f64745268314d222c0037c28', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('c8cafedee9e94df7b51314a2e2855a78', 'bc309c4fca36443493ee890a67e00be8', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('c91723225433486489b9c38aeb8d2122', '59ee07e6edf240e1bbb7c6579755ba97', 'f54be3bd06bc4b2798d823b933538cb6', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('c96356ee96e54c8f994ce069000c6c11', '88be3c8883b341cc98d6bfc24e0000e9', 'f54be3bd06bc4b2798d823b933538cb6', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('c9776d368e59485abf03aa959dd07f69', '5c748957e92841e5b08fcd0729837962', '48acf9ec7e714966a198750303af39c1', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('cb76be2d27274ba1bf32ebe13ded117c', '183e0bb7e7cc44eda5272ccca960e227', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('cc154f4ac448487fae95e3cf2dbc895a', '917b027a2b6a4f7ea93f8c8178744cb8', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('cc233dc6c36d497192a6e283e4f43156', 'ae1bd8b4e787406b931ccf267805282e', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('cc853d2d7d0649a9be650c6654ed828b', '8821fdcf76ad4491b4c2b674fc5804c5', 'f54be3bd06bc4b2798d823b933538cb6', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('ce3c1ef7f07840c29b17ca3c9385c94a', 'd7acc9c3b5c04d348fae6af11c13dfa7', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('ce935104f2dd4091a3a19e2b79c0c102', '5e2a6fc2c56e49c58ab1c6cc6984747d', 'f54be3bd06bc4b2798d823b933538cb6', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('cf350a975eb74e96a7c160f56099a891', '42f93db68ab1454a88339169b4c1f781', 'f54be3bd06bc4b2798d823b933538cb6', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('cf8000eef7ea44b0a661765dbcae3591', 'cba2f933bea340af9fdee2ea06f41cab', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('d02bdb3fa828498f9ac15e7f01c4c26b', '7b88801431d2412da2a7c76f740784ca', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('d101f9b9eaf14c1885e1cdff34af2485', '3234522eb8cc4cd7bd6e36c4ca5038a6', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('d25652efc3a34cafa44189302e6f316e', 'ead05361323a46b38a9c12f534594889', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('d40d9230201d4184aa8d68759a006116', '15869529e4b54322b764b1ad196d15f8', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('d609f567df8a432b9dc2dc797414640c', '6702300594f0476cb405593728a422e2', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('d7e96cb7d28c43e1b64612b8501da531', 'a64ce854a3484aa484a3b3aa1b6fd0a1', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('da3f8ad7962b4368b9c60f1cb38d56f3', '9d3496200b9e484d942806c3df5c9061', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('dc56a1ec5f2f4e659c0ca5c5e566ff87', '7703959ccb1d4dfcac9805c01a8776cf', '48acf9ec7e714966a198750303af39c1', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('dc5793ae544442a6bc29e620fa9fd3a9', 'b22cdad342de47bba9603278d8d06510', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('ddbd439aa0bb43bea2a6774df2e76629', '7c6a0030f3884d13b3935a6411cdcf44', '48acf9ec7e714966a198750303af39c1', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('de03ea4e7cb84bd58478c09d1937f305', '6fb8d519ac8e495eb8abfe16f3f68def', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('de0a9654d6244717885b2458487f948e', 'd42ce5046f48442a86052a946be18544', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('ded90fbf1a3842fab8275fae691cfcd4', 'b64ed45351844cbe8e8767ad33e54b39', '48acf9ec7e714966a198750303af39c1', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('e142cc263bbe45a88e418603e075b642', '1f3b9338b2f84e9f9e9bd6587b9cf3fd', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('e1f29577953a40b59e9a52fc88840a14', '481effad103d4ea7a96e3548966129ab', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('e266ef7a66b844279b124fde8d7f06c3', 'ccb1ee2027c948d7b6e45e161502b724', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('e3534655c25142e2b1cc0b1c4b3ca914', 'b8cdf103d2d94765b3daa148de8dc946', '48acf9ec7e714966a198750303af39c1', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('e35d241fddc44a45989043216226ecd0', '1020ee13119946bba16442b624c2c3ba', '48acf9ec7e714966a198750303af39c1', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('e49da31e31cf4ed6bee202d0d4760191', '0d0786209da3427c9b285ad67add1366', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('e53f1d6ed60148d8b4b7234c83a30c9c', 'cc98355a19034982bd5e0badca1493a2', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('e62b07acf2354e7a8b3163b7634a9138', 'e19539c404b7446c83a8483fb9e056e8', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('e6abd3f3fe1b4ba2b6bb4bc8ef89711d', 'a6e73dbcd2aa4293b716ea314ffb9d17', '48acf9ec7e714966a198750303af39c1', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('e9aa1b7fefc3439cb1ad50cf88e38d21', '1020ee13119946bba16442b624c2c3ba', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('ec1f21cdda5d4bb092305037cce85052', '4274d378f27b46a5aa8277e55354a79d', '48acf9ec7e714966a198750303af39c1', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('ee39774ebcc34c2c8344c545eb0f0901', '23df0b86927c498a90af9fa9eb306b5d', '48acf9ec7e714966a198750303af39c1', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('eef1a466915542bfb7e6218a07b11927', 'b4628aab2ebd4e9cba11f46d2d279137', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('f23061cd5c9849df90f6a5c65c91ecbf', 'be6ae0c503c743679fa5c29529047e0e', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('f34b1157bdfd4f0d84520d194c55b4a2', '549d4f5e80d64581b309fbc61bbdaad7', 'f54be3bd06bc4b2798d823b933538cb6', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('f650a8ebf41a4cf4974d67afc1d5577c', 'b8cdf103d2d94765b3daa148de8dc946', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('f705ae7624044fe780004506c4775854', 'a3adc0ec364b436eb61e7efd6107e6d8', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('f8416a4e2e7b45789cc210ddcbbec699', '142e445581c5452aa49b132a737bf8f4', 'f54be3bd06bc4b2798d823b933538cb6', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('f900b1c03c3945e98b41da968889cb33', 'ead05361323a46b38a9c12f534594889', '48acf9ec7e714966a198750303af39c1', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('f9c3fdf9c3174a9eb0eced3d3bc5a694', '23b1c26eeefe4d2f8cbb9f6c6cddec44', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('fa006d979d8a48369bb7c77935a0e62c', '7b5248ff933746cfa6b8333e009e5fa3', 'f54be3bd06bc4b2798d823b933538cb6', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('fa468c49ee7b46db9cb4b13802ffdce7', 'a1c314cee7784b5db03a96ed53f9da9f', '48acf9ec7e714966a198750303af39c1', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('fc674f454ca7439f85633f46ab062c8e', '106ae703a29a4e9fbb4372ca3f101068', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('fd196f13d2cf4d98ab678ff6afe371f5', '9d08a3fc1afd4222b15d15cdbfe6068e', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('fd78fcbe6a7249ce969138e30b47891f', '0d3fbd8895504e858fd54dfc561afc19', '675d1215b42d423995f82f3abf48818c', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('fe45712e2f1f43b7b63389f1daf7dd85', '23df0b86927c498a90af9fa9eb306b5d', 'f54be3bd06bc4b2798d823b933538cb6', null);
INSERT INTO `Pls_Role_ButtonAction` VALUES ('fe53e6d923f24d76b256605e2ee3a5e4', '9d08a3fc1afd4222b15d15cdbfe6068e', '48acf9ec7e714966a198750303af39c1', null);

-- ----------------------------
-- Table structure for Pls_Shop
-- ----------------------------
DROP TABLE IF EXISTS `Pls_Shop`;
CREATE TABLE `Pls_Shop` (
  `shop_id` varchar(127) NOT NULL,
  `createtime` datetime(6) NOT NULL,
  `disable` int(11) NOT NULL DEFAULT '0',
  `disabledesc` longtext,
  `row_number` longblob,
  `shop_defaultimg` longtext,
  `shop_desc` longtext,
  `shop_isdiscount` bit(1) NOT NULL DEFAULT b'0',
  `shop_memo` varchar(64) NOT NULL,
  `shop_name` varchar(128) NOT NULL,
  `shop_number` varchar(64) NOT NULL,
  `user_id` varchar(64) NOT NULL,
  PRIMARY KEY (`shop_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of Pls_Shop
-- ----------------------------
INSERT INTO `Pls_Shop` VALUES ('678829a2b00d4f94b2f9755132883df7', '2016-12-16 13:46:34.419928', '0', null, null, 'http://images.chuxinm.com/shop/20161216142627476_93889.jpg', '<p><b>1.综合说明</b>&nbsp; &nbsp;&nbsp;<img src=\"http://img.t.sinajs.cn/t4/appstyle/expression/ext/normal/0b/wabi_thumb.gif\"></p><p><font size=\"5\" color=\"#ff0000\">&nbsp; &nbsp; V1.0,V2.0系统只试用于学习，如果要应用于开发中，部分功能尚未开发，需要用户自己在其基础上进行开发和设置(部分重复性的也未开发)。V3.0系统是完整项目，功能开发完整</font><b><br></b></p><p><b>2.版本简单介绍</b>&nbsp; &nbsp;&nbsp;<img src=\"http://img.t.sinajs.cn/t4/appstyle/expression/ext/normal/9f/huatongv2_thumb.gif\"></p><p>&nbsp; <font size=\"3\">&nbsp; ①：V1.0无数据库版 此版本没有对应的数据库文件，只有源码，需要用户自己根据源码生成数据库并且填充数据库文件中的数据。<br></font></p><p><font size=\"3\">&nbsp; &nbsp; ②：V2.0有数据库版 此版本含有对应的数据库文件，用户只需要按照下面的方式配置系统即可访问系统。</font></p><p><font size=\"3\">&nbsp; &nbsp; ③：V3.0项目版 此版本为一个正式的项目源码(内含备份数据库)，还原备份数据库并且修改连接字符串便可运行，项目业务为：教育行业院校征订系统。<br></font></p><p style=\"line-height: 1.5;\"><b>2.如何运行项目</b>&nbsp; &nbsp;&nbsp;<img src=\"http://img.t.sinajs.cn/t4/appstyle/expression/ext/normal/6d/zhh_thumb.gif\"><br><font size=\"3\">&nbsp; &nbsp; 1.首先使用Visual Studio 2012打开项目，生成数据库文件(如果不懂如何生成数据库文件，请自行学习EntityFramework ModelFirst生成数据库)，数据库生成之后，如果您购买的是含有数据库数据文件的，则如下图所示您可以看到数据文件，拷贝到你生成的数据库中执行即可。如果您购买的是没有数据库文件的，则需要自己生成。</font><br></p><p>&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<img src=\"http://images.chuxinm.com/shop/20161219111350557_11955.png\" alt=\"QQ截图20161219111319\" style=\"max-width: 100%;\" class=\"\"><br></p><p>&nbsp; &nbsp; 2.V3.0项目版本备份数据库在项目根目录下App_Data文件夹下，附加到数据库中即可运行<br></p><p>&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<img src=\"http://images.chuxinm.com/shop/20170217154540710_4809.png\" alt=\"\" style=\"max-width: 100%;\"><br></p><p>&nbsp; &nbsp; 3.生成数据库之后，则找到找到web.config文件，找到数据库连接字符串(connectionStrings)，修改数据库的连接字符串为您自己的连接字符串</p><p>&nbsp;&nbsp;&nbsp;&nbsp;&lt;add&nbsp;name=\"DataModelContainer1\"&nbsp;connectionString=\"metadata=res://*/DataModel.csdl|res://*/DataModel.ssdl|res://*/DataModel.msl;</p><p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;provider=System.Data.SqlClient;provider&nbsp;connection&nbsp;string=\"data&nbsp;source=.;initial&nbsp;catalog=LYZJShopDB;persist&nbsp;security&nbsp;info=True;</p><p>&nbsp; &nbsp; &nbsp; &nbsp; user&nbsp;id=sa;password=sql2008;multipleactiveresultsets=True;application&nbsp;name=EntityFramework\"\"&nbsp;</p><p>&nbsp; &nbsp; &nbsp; &nbsp; providerName=\"System.Data.EntityClient\"&nbsp;/&gt;</p><p>&nbsp; &nbsp; 4. 修改完成之后，启动项目，运行成功,页面上本来所带的就是用户需要登陆的账号，用户登录即可看到内部页面。部分页面未实现功能，需要用户自己去实现<br></p><p>&nbsp; &nbsp; 5. 我的目标就是购买者能够学到如何使用MVC和Entity Framework和Linq即可~</p><p><b>3.项目展示</b>&nbsp; &nbsp;&nbsp;<img src=\"http://img.t.sinajs.cn/t4/appstyle/expression/ext/normal/92/fan.gif\"></p><p>&nbsp; &nbsp;* 第一张图片<br></p><p>&nbsp; &nbsp;&nbsp;<img src=\"http://images.chuxinm.com/shop/20161219112141208_77813.png\" alt=\"QQ截图20161219112012\" style=\"max-width: 100%;\"><br></p><p>&nbsp; &nbsp;* 第二张图片 &nbsp; &nbsp;&nbsp;</p><p><img src=\"http://images.chuxinm.com/shop/20161219112156485_100601.png\" alt=\"QQ截图20161219112024\" style=\"max-width: 100%;\" class=\"\"></p><p>&nbsp;* 第三张图片<img src=\"http://images.chuxinm.com/shop/20161219112219402_62861.png\" alt=\"QQ截图20161219112031\" class=\"\" style=\"max-width: 100%;\"></p><p><b>4.V3.0项目介绍</b>&nbsp; &nbsp;&nbsp;<img src=\"http://img.t.sinajs.cn/t4/appstyle/expression/ext/normal/92/fan.gif\"></p><p>&nbsp; &nbsp; 1. 项目功能齐全，完全部署之后可以访问。</p><p>&nbsp; &nbsp; 2. 项目功能为经销存系统，含有很多特殊的业务~<br></p><p>&nbsp; &nbsp; 3. 本项目只限于购买者学习以及参考开发</p><p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.....................</p><p><br></p><p><br></p>', '\0', '适用于构建中小型系统基础权限、MVC系统学习等', ' ASP.NET MVC+EF+EasyUI权限管理信息系统', '#24725761_247', '66dbea2b41dd47a1a81eef2e5dc2af0e');
INSERT INTO `Pls_Shop` VALUES ('8c2e2aff9290446ababf9c5905fa2609', '2016-12-16 15:29:43.267729', '0', null, null, 'http://images.chuxinm.com/shop/20161216155125580_425716.png', '<p><b>1.综合说明&nbsp;</b> &nbsp;&nbsp;<img src=\"http://img.t.sinajs.cn/t4/appstyle/expression/ext/normal/0b/wabi_thumb.gif\"></p><p><font color=\"#ff0000\" size=\"5\">&nbsp; &nbsp; (1):V1.0系统为基础权限信息(部门-用户-角色-权限)，用户可在个人中心中申请访问后台，访问地址：<a href=\"http://www.chuxinm.com\" target=\"_blank\">http://www.chuxinm.com</a>权限控制到按钮级别。</font></p><p><span style=\"line-height: 1;\">&nbsp; &nbsp;&nbsp;</span><span style=\"line-height: 1;\">&nbsp; &nbsp;&nbsp;</span><span style=\"line-height: 43.2px; color: rgb(255, 0, 0); font-size: x-large;\">购买系统的系统默认管理员账户为：(用户名：18658152123，密码：123456)</span></p><p><font color=\"#ff0000\" size=\"5\">&nbsp; &nbsp; (2):V2.0系统为本项目基于1.0的权限实现，源码就是本项目所运行的源码，本项目访问地址：<a href=\"http://www.chuxinm.com\" target=\"_blank\">http://www.chuxinm.com</a>。</font></p><p>2.如何运行项目&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"http://img.t.sinajs.cn/t4/appstyle/expression/ext/normal/6d/zhh_thumb.gif\"></p><p>&nbsp; &nbsp;1.首先使用Visual Studio 2015打开项目，找到如下图所示数据库文件，打开Mysql数据库管理工具，将数据库文件执行成功。</p><p>&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<img src=\"http://images.chuxinm.com/shop/20161219135711241_9283.png\" alt=\"QQ截图20161219133316\" style=\"max-width: 100%;\" class=\"clicked\"><br></p><p>&nbsp; &nbsp; 2.生成数据库文件之后，需要修改数据库连接字符串，如图所示：找到源码中的文件进行修改</p><p><img src=\"http://images.chuxinm.com/shop/20161219140145146_9839.png\" style=\"max-width: 100%;\"><br></p><p>&nbsp; &nbsp; 3. 修改完成之后，启动项目，运行成功,页面上本来所带的就是用户需要登陆的账号，用户登录即可看到内部页面。</p><p>3.项目使用技术&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"http://img.t.sinajs.cn/t4/appstyle/expression/ext/normal/58/mb_thumb.gif\"></p><p>&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<img src=\"http://images.chuxinm.com/shop/20161219140326504_9709.png\" alt=\"QQ截图20161219140258\" style=\"max-width: 100%;\" class=\"\"><br></p><p><img src=\"http://images.chuxinm.com/shop/20170311181709888_14967.png\" alt=\"\" style=\"max-width:100%;\"><br></p><p>4.项目展示&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"http://img.t.sinajs.cn/t4/appstyle/expression/ext/normal/92/fan.gif\"></p><p>&nbsp; &nbsp;&nbsp;<img src=\"http://images.chuxinm.com/shop/20161219140400066_11749.png\" alt=\"QQ截图20161219133349\" style=\"max-width: 100%;\" class=\"\"><img src=\"http://images.chuxinm.com/shop/20161219140414223_103073.png\" alt=\"QQ截图20161219133309\" style=\"max-width: 100%;\"><img src=\"http://images.chuxinm.com/shop/20161219140430076_37459.png\" alt=\"QQ截图20161219133325\" style=\"max-width: 100%;\"><img src=\"http://images.chuxinm.com/shop/20161219140455020_92563.png\" alt=\"QQ截图20161219140439\" style=\"max-width: 100%;\"><br></p><p><br></p>', '\0', '适用于构建跨平台中大型系统基础权限、ASP.NET Core学习', 'ASP.NET Core+EF Core+BootStrap基础权限系统', '#32348185_323', '66dbea2b41dd47a1a81eef2e5dc2af0e');
INSERT INTO `Pls_Shop` VALUES ('8e4ed35c61c3488797d46e69a5ed8551', '2017-03-09 11:33:02.458629', '0', null, null, null, '<p><img src=\"http://images.chuxinm.com/shop/20170309113231907_90726.jpg\" alt=\"58DXHM_DO[_UCV5X2A0AL7Q\" style=\"max-width:100%;\"><img src=\"http://images.chuxinm.com/shop/20170309113241887_47360.png\" alt=\"1T0U@F97W[Z~UXTLG9WY`BP\" style=\"line-height: 1; max-width: 100%;\"><img src=\"http://images.chuxinm.com/shop/20170309113250454_70441.png\" alt=\"~(916XDAAN(5SH)[I)A9Z}B\" style=\"line-height: 1; max-width: 100%;\"><br></p><p>力软敏捷开发框架 专业版</p><p>体验地址：<a href=\"http://lr.hsucai.cn:81/\" target=\"_blank\" style=\"background-color: rgb(255, 255, 255);\">http://lr.hsucai.cn:81/</a></p><p>用户名：system&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;密码：0000</p><p>系统简介：（1）后台采用MVC+EF架构，前台使用Jquery+Bootstrap,界面美观大气，同时支持灵活定制各种美观的界面。（2）系统模块化的架构设计，使得系统前端支持web页面、webapp，微信等客户端，采用SOA架构，扩展升级灵活。（3）框架支持Sqlserver、Mysql、Oracle等多种数据库。在同一系统中可同时连接多个数据库、多个数据库可以是不同类型的数据库（4）灵活通用的工作流和表单构建方式，满足了常用系统的OA流程办公。（5）系统具有通用的组织架构、权限控制、报表输出功能。</p><p>（6）系统添加了单点登录、访问过滤，缓存机制等等。</p><p>运行环境：vs2015+ SQL Server 2012</p><p>一、解决方案简介：1、Code 底层核心类（开发时不涉及，可编绎成dll提供）。2、Data 数据层（开发时不涉及，可编绎成dll提供）。3、Application&nbsp;&nbsp;应用（有点类似业务逻辑层）&nbsp;4、Domain 领域层。5、Mapping 数据库映射。6、Repository 数据访问。7、Web 前端视图及控制器。二、框架主要运用技术：1、前端技术JS框架：jquery-2.1.1、Bootstrap.js、JQuery UICSS框架：Bootstrap v3.3.4（稳定是后台，UI方面根据需求自己升级改造吧）。客户端验证：jQuery Validation Plugin 1.9.0。在线编辑器：ckeditor、simditor上传文件：Uploadify v3.2.1动态页签：Jerichotab（自己改造）数据表格：jqGrid、Bootstrap Talbe对话框：layer-v2.3下拉选择框：jQuery Select2树结构控件：jQuery zTree、jQuery wdtree页面布局：jquery.layout.js 1.4.4图表插件：echarts、highcharts日期控件： My97DatePicker2、后端技术</p><p>核心框架：ASP.NET MVC5、WEB API持久层框架：EntityFramework 6.0定时计划任务：Quartz.Net组件安全支持：过滤器、Sql注入、请求伪造服务端验证：实体模型验证、自己封装Validator缓存框架：微软自带Cache、Redis日志管理：Log4net、登录日志、操作日志工具类：NPOI、Newtonsoft.Json、验证码、丰富公共类似</p><p><br></p><p><br></p>', '\0', '敏捷开发版6.1', '力软.net快速开发框架,MVC,EF架构,工作流源码(敏捷开发版6.1)', '#46774154_467', '66dbea2b41dd47a1a81eef2e5dc2af0e');
INSERT INTO `Pls_Shop` VALUES ('98e4b3536d7a4dd599d29e7ac9de5248', '2016-12-16 11:30:16.207159', '0', null, null, 'http://images.chuxinm.com/shop/20161216114541679_90701.jpg', '<p><b>1.项目简易说明</b>&nbsp; &nbsp;&nbsp;<img src=\"http://img.t.sinajs.cn/t4/appstyle/expression/ext/normal/5c/huanglianwx_thumb.gif\"></p><p>&nbsp;&nbsp;&nbsp;&nbsp;(1).项目前台：LYSC.CompanyWeb.UI/Index.html</p><p>&nbsp;&nbsp;&nbsp;&nbsp;(2).项目后台：LYSC.CompanyWeb.UI/admin/Login/Login.aspx</p><p>&nbsp;&nbsp;&nbsp;&nbsp;(3).项目数据库脚本：LYSC.CompanyWeb.UI/DateFile</p><p>&nbsp;&nbsp;&nbsp;&nbsp;(4).项目说明以及开发流程：LYSC.CompanyWeb.UI/DateFile</p><p>&nbsp;&nbsp;&nbsp;&nbsp;(5).此项目是基于VS2012开发的，数据库是VS2012</p><p>&nbsp;&nbsp;&nbsp;&nbsp;(6).NET版本是.net FrameWork 4.5</p><p>&nbsp;&nbsp;&nbsp;&nbsp;(7).如须知道开发过程中遇到的问题，可以查看第4步的文件</p><p><b>2.如何运行项目</b>&nbsp; &nbsp;&nbsp;<img src=\"http://img.t.sinajs.cn/t4/appstyle/expression/ext/normal/6d/zhh_thumb.gif\"></p><p>&nbsp;&nbsp;&nbsp;&nbsp;1. &nbsp;如何运行项目</p><p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(1):(数据库)首要找到数据库脚本(数据库脚本在跟项目下的LYSC.CompanyWeb.UI/DateFile)，将数据库脚本拷贝到你的</p><p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(2):数据库脚本执行完成之后，使用VS2012打开项目，打开项目之后找到web.config文件，找到数据库连接字符串(appSettings</p><p>)，修改数据库的连接字符串为您自己的连接字符串</p><p>&nbsp;&nbsp;&nbsp;&nbsp;&lt;add key=\"ConnectionString\"\r\nvalue=\"server=.;database=bjhksj;uid=sa;pwd=saa\"/&gt;</p><p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(3) 修改完成之后，启动项目，运行成功（首页：127.0.0.1/Index.html，后台管理页面(127.0.0.1/ admin/Login/Login.aspx)）后台登录账号：(用户名：hyl，密码:hyl)</p><p><b>3.项目使用技术</b>&nbsp; &nbsp;&nbsp;<img src=\"http://img.t.sinajs.cn/t4/appstyle/expression/ext/normal/58/mb_thumb.gif\"></p><p>&nbsp; &nbsp; ①：Asp.NET WebForm+Ashx+Easyui</p><p>&nbsp; &nbsp; ②：SqlSever2008以上</p><p>&nbsp; &nbsp; ③：kindeditor等插件</p><p><b>4.项目展示</b>&nbsp; &nbsp;&nbsp;<img src=\"http://img.t.sinajs.cn/t4/appstyle/expression/ext/normal/92/fan.gif\"></p><p><img src=\"http://images.chuxinm.com/shop/20161216130759351_46871.jpg\" alt=\"234234234\" style=\"max-width: 100%;\"><br></p><p><img src=\"http://images.chuxinm.com/shop/20161216130823886_82260.png\" alt=\"QQ截图20161216130100\" style=\"max-width:100%;\" class=\"\"><br></p><p><img src=\"http://images.chuxinm.com/shop/20161216130840384_58958.png\" alt=\"QQ截图20161216130117\" style=\"max-width:100%;\"><br></p><p><br></p>', '\0', '适用于构建企业门户网站、毕业设计等', 'Asp.NET WebForm+Ashx+EasyUI门户网站系统', '#64401270_644', '66dbea2b41dd47a1a81eef2e5dc2af0e');
INSERT INTO `Pls_Shop` VALUES ('b88e9907dbaa4b3db297443081ab238d', '2016-12-22 11:07:27.980030', '0', null, null, 'http://images.chuxinm.com/shop/20161222111023610_31625.png', '<p>详细博客说明：</p><p>&nbsp; 第一篇： &nbsp;<a href=\"http://www.cnblogs.com/hanyinglong/archive/2012/05/24/2517000.html\" target=\"_blank\" style=\"background-color: rgb(255, 255, 255);\">http://www.cnblogs.com/hanyinglong/archive/2012/05/24/2517000.html</a><br></p><p>&nbsp; 第二篇：<a href=\"http://www.cnblogs.com/hanyinglong/archive/2012/05/25/2517677.html\" target=\"_blank\" style=\"background-color: rgb(255, 255, 255);\">http://www.cnblogs.com/hanyinglong/archive/2012/05/25/2517677.html</a></p><p>因系统开发好久了，当时写的一些简单说明，现在开放出去，希望大家能从中学到更多的指示，费用为辛苦费吧，希望大家理解</p><p><br></p>', '\0', '学习使用Sping.net和Nihibernate的不二选择', 'ASP.NET MVC+Spring.net+Nhibernate+EasyUI学习系统', '#11087261_110', '66dbea2b41dd47a1a81eef2e5dc2af0e');
INSERT INTO `Pls_Shop` VALUES ('c9b931bfc224435c8e3cc2005293294c', '2017-03-09 11:24:37.178459', '0', null, null, null, '<p>432424324</p>', '\0', '23423', '3242', '#43422265_434', '66dbea2b41dd47a1a81eef2e5dc2af0e');
INSERT INTO `Pls_Shop` VALUES ('e0441f1fdcc24593975ddfc301f294d3', '2017-03-11 10:44:18.551061', '0', '{\'disable\':\'0\',\'disable_desc\':\'dsf\'},{\'disable\':\'1\',\'disable_desc\':\'sdf\'}', null, null, '<p>asdf</p>', '\0', 'asdf', 'asdfa', '#66674876_666', 'cc64df824a6747e09ceb4aa926fed05a');

-- ----------------------------
-- Table structure for Pls_ShopAttr
-- ----------------------------
DROP TABLE IF EXISTS `Pls_ShopAttr`;
CREATE TABLE `Pls_ShopAttr` (
  `shopattr_id` varchar(127) NOT NULL,
  `row_number` longblob,
  `shop_id` varchar(64) NOT NULL,
  `shopattr_author` varchar(64) DEFAULT NULL,
  `shopattr_blogaddress` varchar(128) DEFAULT NULL,
  `shopattr_condition` varchar(64) DEFAULT NULL,
  `shopattr_database` varchar(64) DEFAULT NULL,
  `shopattr_framework` varchar(64) DEFAULT NULL,
  `shopattr_isopensource` bit(1) NOT NULL DEFAULT b'0',
  `shopattr_language` varchar(64) DEFAULT NULL,
  `shopattr_manage` varchar(64) DEFAULT NULL,
  `shopattr_memo` varchar(256) DEFAULT NULL,
  `shopattr_opensource` varchar(64) DEFAULT NULL,
  `shopattr_size` double NOT NULL,
  `shopattr_utf` varchar(64) DEFAULT NULL,
  `shopattr_weburl` varchar(128) DEFAULT NULL,
  PRIMARY KEY (`shopattr_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of Pls_ShopAttr
-- ----------------------------
INSERT INTO `Pls_ShopAttr` VALUES ('0dae0bdab1b945c494e974a9476b441d', null, 'b88e9907dbaa4b3db297443081ab238d', 'Kencery', 'http://www.cnblogs.com/hanyinglong/archive/2012/05/24/2517000.html', 'Visual Studio2010', 'sqlserver2008', 'B/S', '', 'ASP.NET MVC+Spring.net+Nhibernate+EasyUI+Jquery', 'svn', null, 'BSD开源协议', '4.5', 'utf-8', null);
INSERT INTO `Pls_ShopAttr` VALUES ('4e4445f0598a49a79791e3a0163dcb64', null, '8e4ed35c61c3488797d46e69a5ed8551', '1', null, '1', 'vs2015+ SQL Server 2012', 'B/S', '\0', 'c#', null, null, null, '1', null, null);
INSERT INTO `Pls_ShopAttr` VALUES ('7bc272fec15c418b906d080f1e8ab314', null, '8c2e2aff9290446ababf9c5905fa2609', 'Kencery', null, 'Visual Studio2015', 'MySql5.6.34', 'B/S', '', 'Asp.net Core+EF Core', 'git', null, 'BSD开源协议', '16.7', 'UTF-8', 'http://www.chuxinm.com/');
INSERT INTO `Pls_ShopAttr` VALUES ('ae425ee15e114e72917a63777428aff4', null, '678829a2b00d4f94b2f9755132883df7', 'Kencery', 'http://www.cnblogs.com/hanyinglong/archive/2012/12/13/mvc.html', 'Visual Studio2012', 'sqlserver2008', 'B/S', '', 'Asp.net Mvc+EntityFramework', 'git', null, 'BSD开源协议', '17', 'UTF-8', null);
INSERT INTO `Pls_ShopAttr` VALUES ('c8352506ebf847e2996a5688f22b902b', null, '98e4b3536d7a4dd599d29e7ac9de5248', 'Kencery', 'http://www.cnblogs.com/hanyinglong/archive/2012/11/12/2766769.html', 'Visual Studio2012', 'Sql2008以上', 'B/S', '', 'Asp.NET WebForm+Ashx', 'svn', null, 'BSD开源协议', '10', 'UTF8', null);

-- ----------------------------
-- Table structure for Pls_ShopCoupon
-- ----------------------------
DROP TABLE IF EXISTS `Pls_ShopCoupon`;
CREATE TABLE `Pls_ShopCoupon` (
  `shopcoupon_id` varchar(127) NOT NULL,
  `createtime` datetime(6) NOT NULL,
  `disable` int(11) NOT NULL DEFAULT '0',
  `endtime` datetime(6) NOT NULL,
  `row_number` longblob,
  `shop_id` varchar(64) NOT NULL,
  `shopcoupon_money` double NOT NULL,
  `shopcoupon_name` varchar(128) NOT NULL,
  `shopcoupon_type` varchar(64) NOT NULL,
  PRIMARY KEY (`shopcoupon_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of Pls_ShopCoupon
-- ----------------------------
INSERT INTO `Pls_ShopCoupon` VALUES ('aa0db90009844a3aba3454cb0f07dbae', '2016-12-16 13:11:45.419954', '1', '2017-01-31 00:00:00.000000', null, '98e4b3536d7a4dd599d29e7ac9de5248', '5', '现在购买享受年终大促特大优惠', '年终大促');
INSERT INTO `Pls_ShopCoupon` VALUES ('dd4b887b3546416faec99f3cd70b1af5', '2016-12-16 14:45:56.008250', '1', '2017-01-31 00:00:00.000000', null, '678829a2b00d4f94b2f9755132883df7', '10', '现在购买享受年终大促特大优惠', '年终大促');
INSERT INTO `Pls_ShopCoupon` VALUES ('dec4f0a3e0fd489989d9dcc9fdc5fc99', '2016-12-16 15:53:07.990982', '1', '2017-01-31 00:00:00.000000', null, '8c2e2aff9290446ababf9c5905fa2609', '10', '现在购买享受年终大促特大优惠', '年终大促');

-- ----------------------------
-- Table structure for Pls_ShopImage
-- ----------------------------
DROP TABLE IF EXISTS `Pls_ShopImage`;
CREATE TABLE `Pls_ShopImage` (
  `shopimage_id` varchar(127) NOT NULL,
  `disable` int(11) NOT NULL DEFAULT '0',
  `row_number` longblob,
  `shop_id` varchar(64) NOT NULL,
  `shopimage_address` varchar(128) NOT NULL,
  `shopimage_default` bit(1) NOT NULL DEFAULT b'0',
  `shopsku_id` varchar(64) NOT NULL,
  PRIMARY KEY (`shopimage_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of Pls_ShopImage
-- ----------------------------
INSERT INTO `Pls_ShopImage` VALUES ('36859371e5354c4e8aa5b0c9d44ab45b', '0', null, '678829a2b00d4f94b2f9755132883df7', 'http://images.chuxinm.com/shop/20161216142652042_144535.jpg', '\0', 'f77508c3b9824c0c866733d5d6372579');
INSERT INTO `Pls_ShopImage` VALUES ('38d647a40f1647b3a63517d37406d316', '0', null, '8c2e2aff9290446ababf9c5905fa2609', 'http://images.chuxinm.com/shop/20161219133410463_103073.png', '\0', '87d3e75f7f1142b0af217e0014724851');
INSERT INTO `Pls_ShopImage` VALUES ('540307e7894c49028dae3cc3a099c04c', '0', null, '678829a2b00d4f94b2f9755132883df7', 'http://images.chuxinm.com/shop/20161219115742812_70140.png', '\0', 'fefac66ab383418fa00ce2b546db7127');
INSERT INTO `Pls_ShopImage` VALUES ('57ce79a6e35d4f939527706c40ef705f', '0', null, '678829a2b00d4f94b2f9755132883df7', 'http://images.chuxinm.com/shop/20161219112119027_77813.png', '\0', 'f77508c3b9824c0c866733d5d6372579');
INSERT INTO `Pls_ShopImage` VALUES ('5c2f432992b14218a68f39cec53abdbc', '0', null, 'b88e9907dbaa4b3db297443081ab238d', 'http://images.chuxinm.com/shop/20161222111021260_21015.png', '\0', '32750164a8a640d8aafc69675c845323');
INSERT INTO `Pls_ShopImage` VALUES ('62b18b46e66741cfaf3b006d099efb89', '0', null, '8c2e2aff9290446ababf9c5905fa2609', 'http://images.chuxinm.com/shop/20161216153351073_41320.png', '\0', '9bc99843c3ad401180bd31b152bf338a');
INSERT INTO `Pls_ShopImage` VALUES ('6a590d1e81374da4886562fe7d922f66', '0', null, '678829a2b00d4f94b2f9755132883df7', 'http://images.chuxinm.com/shop/20161216142627476_93889.jpg', '', '1a58c0ae75cc4f4a920b3a65a6f6a20d');
INSERT INTO `Pls_ShopImage` VALUES ('7178bc03202d485b9c49e6d475228702', '1', null, '98e4b3536d7a4dd599d29e7ac9de5248', 'http://images.chuxinm.com/shop/20161216114544842_46871.jpg', '\0', '6d622b04c65949eca161ada82bffcbd7');
INSERT INTO `Pls_ShopImage` VALUES ('7452d814d9674fa0985dcb04ebdde539', '0', null, '678829a2b00d4f94b2f9755132883df7', 'http://images.chuxinm.com/shop/20161219115736813_189189.png', '\0', 'fefac66ab383418fa00ce2b546db7127');
INSERT INTO `Pls_ShopImage` VALUES ('75fc20ac1f55434183095497c0f0f912', '0', null, 'b88e9907dbaa4b3db297443081ab238d', 'http://images.chuxinm.com/shop/20161222111023610_31625.png', '', '32750164a8a640d8aafc69675c845323');
INSERT INTO `Pls_ShopImage` VALUES ('7712a938aa604eff9a441473466f4a32', '0', null, '8c2e2aff9290446ababf9c5905fa2609', 'http://images.chuxinm.com/shop/20161219133418378_37459.png', '\0', '87d3e75f7f1142b0af217e0014724851');
INSERT INTO `Pls_ShopImage` VALUES ('7fa22fb08342466586cda711d7bc9121', '0', null, '98e4b3536d7a4dd599d29e7ac9de5248', 'http://images.chuxinm.com/shop/20161216114537709_22427.jpg', '\0', '6d622b04c65949eca161ada82bffcbd7');
INSERT INTO `Pls_ShopImage` VALUES ('900b11542a3a45788e9d00c815bf3372', '0', null, '8c2e2aff9290446ababf9c5905fa2609', 'http://images.chuxinm.com/shop/20161219133406871_43288.png', '\0', '87d3e75f7f1142b0af217e0014724851');
INSERT INTO `Pls_ShopImage` VALUES ('93bb78866e014cb3aa01fb662f908978', '0', null, '98e4b3536d7a4dd599d29e7ac9de5248', 'http://images.chuxinm.com/shop/20161216114548219_79483.jpg', '\0', '6d622b04c65949eca161ada82bffcbd7');
INSERT INTO `Pls_ShopImage` VALUES ('9b8d01ebc85e4aa1b7c979e87ce86af1', '0', null, '678829a2b00d4f94b2f9755132883df7', 'http://images.chuxinm.com/shop/20161216142633969_74614.jpg', '\0', '1a58c0ae75cc4f4a920b3a65a6f6a20d');
INSERT INTO `Pls_ShopImage` VALUES ('9cc0ccfef7144863afbcb24123801b04', '0', null, '98e4b3536d7a4dd599d29e7ac9de5248', 'http://images.chuxinm.com/shop/20161216114541679_90701.jpg', '', '6d622b04c65949eca161ada82bffcbd7');
INSERT INTO `Pls_ShopImage` VALUES ('9f1ade1ef44e4f9eb15a98eccbdb7b74', '0', null, 'b88e9907dbaa4b3db297443081ab238d', 'http://images.chuxinm.com/shop/20161222111016530_30519.png', '\0', '32750164a8a640d8aafc69675c845323');
INSERT INTO `Pls_ShopImage` VALUES ('a114732095bd4862bcd76c8485c3ba73', '0', null, '678829a2b00d4f94b2f9755132883df7', 'http://images.chuxinm.com/shop/20161216142630752_25077.jpg', '\0', '1a58c0ae75cc4f4a920b3a65a6f6a20d');
INSERT INTO `Pls_ShopImage` VALUES ('a2f857c98c1448d491e20ab238a117e6', '0', null, '678829a2b00d4f94b2f9755132883df7', 'http://images.chuxinm.com/shop/20161216142637111_53554.jpg', '\0', '1a58c0ae75cc4f4a920b3a65a6f6a20d');
INSERT INTO `Pls_ShopImage` VALUES ('a3a7305717fc48bb855dc34951db88d6', '0', null, 'b88e9907dbaa4b3db297443081ab238d', 'http://images.chuxinm.com/shop/20161222111029251_13601.png', '\0', '32750164a8a640d8aafc69675c845323');
INSERT INTO `Pls_ShopImage` VALUES ('a8188fab87b644c6bd718d6b3190c613', '0', null, '678829a2b00d4f94b2f9755132883df7', 'http://images.chuxinm.com/shop/20161219115240598_109742.png', '\0', 'fefac66ab383418fa00ce2b546db7127');
INSERT INTO `Pls_ShopImage` VALUES ('aa040959a0604a6982dfe21800184138', '0', null, '98e4b3536d7a4dd599d29e7ac9de5248', 'http://images.chuxinm.com/shop/20161216130759351_46871.jpg', '\0', '6d622b04c65949eca161ada82bffcbd7');
INSERT INTO `Pls_ShopImage` VALUES ('ae7e382e1fce43b3b3aec9918cf0cd5d', '0', null, '8c2e2aff9290446ababf9c5905fa2609', 'http://images.chuxinm.com/shop/20161216153303280_23322.png', '\0', '9bc99843c3ad401180bd31b152bf338a');
INSERT INTO `Pls_ShopImage` VALUES ('b469e20e26e84cc89444912dea920169', '0', null, '8c2e2aff9290446ababf9c5905fa2609', 'http://images.chuxinm.com/shop/20161219133413683_356184.png', '\0', '87d3e75f7f1142b0af217e0014724851');
INSERT INTO `Pls_ShopImage` VALUES ('b4fa0899541b4877a5387d607412b8f3', '0', null, '8c2e2aff9290446ababf9c5905fa2609', 'http://images.chuxinm.com/shop/20161216155125580_425716.png', '', '9bc99843c3ad401180bd31b152bf338a');
INSERT INTO `Pls_ShopImage` VALUES ('d41de7c183414bb59fa6e87e03282a01', '1', null, '8c2e2aff9290446ababf9c5905fa2609', 'http://images.chuxinm.com/shop/20161216155011016_344734.png', '\0', '9bc99843c3ad401180bd31b152bf338a');
INSERT INTO `Pls_ShopImage` VALUES ('d52282426def4b9d87e764a5f623603f', '0', null, '8c2e2aff9290446ababf9c5905fa2609', 'http://images.chuxinm.com/shop/20161216153404666_34301.png', '\0', '9bc99843c3ad401180bd31b152bf338a');
INSERT INTO `Pls_ShopImage` VALUES ('de05fbce036545edace113cf12a00cd5', '1', null, '8c2e2aff9290446ababf9c5905fa2609', 'http://images.chuxinm.com/shop/20161216154926510_215595.png', '\0', '9bc99843c3ad401180bd31b152bf338a');
INSERT INTO `Pls_ShopImage` VALUES ('e111c900c6d5496b9f8276266406af4f', '1', null, '678829a2b00d4f94b2f9755132883df7', 'http://images.chuxinm.com/shop/20161219115322949_127108.png', '\0', 'fefac66ab383418fa00ce2b546db7127');
INSERT INTO `Pls_ShopImage` VALUES ('e12985515f274853b94c3a4f71f366b0', '0', null, '678829a2b00d4f94b2f9755132883df7', 'http://images.chuxinm.com/shop/20161216142646321_54315.jpg', '\0', 'f77508c3b9824c0c866733d5d6372579');
INSERT INTO `Pls_ShopImage` VALUES ('e38a3fcf2818466c93ffec52fbefb270', '0', null, '678829a2b00d4f94b2f9755132883df7', 'http://images.chuxinm.com/shop/20161219115749456_65712.png', '\0', 'fefac66ab383418fa00ce2b546db7127');
INSERT INTO `Pls_ShopImage` VALUES ('ece48fb980df4a36be0eb1cfa0bda954', '0', null, 'e0441f1fdcc24593975ddfc301f294d3', 'http://images.chuxinm.com/shop/20170311104529517_60838.png', '\0', '71db306c27744579baa36b9d70432af9');
INSERT INTO `Pls_ShopImage` VALUES ('f0c5c5a74faa451b94d5c055458de4b3', '0', null, '678829a2b00d4f94b2f9755132883df7', 'http://images.chuxinm.com/shop/20161216144354255_19787.png', '\0', 'f77508c3b9824c0c866733d5d6372579');
INSERT INTO `Pls_ShopImage` VALUES ('f3a7bd915c82423db7d34f6098a20fe6', '1', null, '8c2e2aff9290446ababf9c5905fa2609', 'http://images.chuxinm.com/shop/20161216153258535_285354.png', '\0', '9bc99843c3ad401180bd31b152bf338a');

-- ----------------------------
-- Table structure for Pls_ShopSku
-- ----------------------------
DROP TABLE IF EXISTS `Pls_ShopSku`;
CREATE TABLE `Pls_ShopSku` (
  `shopsku_id` varchar(127) NOT NULL,
  `createtime` datetime(6) NOT NULL,
  `disable` int(11) NOT NULL DEFAULT '0',
  `row_number` longblob,
  `shop_code` varchar(128) NOT NULL,
  `shop_id` varchar(64) NOT NULL,
  `shopsku_code` varchar(128) DEFAULT NULL,
  `shopsku_currentprice` longtext NOT NULL,
  `shopsku_originalprice` longtext NOT NULL,
  `shopsku_url` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`shopsku_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of Pls_ShopSku
-- ----------------------------
INSERT INTO `Pls_ShopSku` VALUES ('1a58c0ae75cc4f4a920b3a65a6f6a20d', '2016-12-16 13:47:55.071228', '0', null, 'V2.0有数据库版', '678829a2b00d4f94b2f9755132883df7', null, '66.66', '100', 'http://pan.baidu.com/s/1c1JgmSK');
INSERT INTO `Pls_ShopSku` VALUES ('32750164a8a640d8aafc69675c845323', '2016-12-22 11:07:53.248085', '0', null, 'V1.0终结版', 'b88e9907dbaa4b3db297443081ab238d', '无', '5', '10', 'http://download.csdn.net/detail/hanyinglong/4328749');
INSERT INTO `Pls_ShopSku` VALUES ('6d622b04c65949eca161ada82bffcbd7', '2016-12-16 11:31:25.645024', '0', null, 'V1.0最终版', '98e4b3536d7a4dd599d29e7ac9de5248', '27nu', '20', '50', 'http://pan.baidu.com/s/1nuCcdh3');
INSERT INTO `Pls_ShopSku` VALUES ('71db306c27744579baa36b9d70432af9', '2017-03-11 10:45:20.818110', '0', null, 'ewrsaf', 'e0441f1fdcc24593975ddfc301f294d3', 'qwer', '12', '12', 'ewrqwer');
INSERT INTO `Pls_ShopSku` VALUES ('87d3e75f7f1142b0af217e0014724851', '2016-12-19 13:31:25.842787', '0', null, 'V2.0.0商城版', '8c2e2aff9290446ababf9c5905fa2609', '暂无', '520', '1000', '暂无');
INSERT INTO `Pls_ShopSku` VALUES ('9bc99843c3ad401180bd31b152bf338a', '2016-12-16 15:30:05.472682', '0', null, 'V1.0.0权限版', '8c2e2aff9290446ababf9c5905fa2609', 'dykf', '66.66', '100', 'https://pan.baidu.com/s/1i44NstJ');
INSERT INTO `Pls_ShopSku` VALUES ('f77508c3b9824c0c866733d5d6372579', '2016-12-15 13:47:10.245232', '0', null, 'V1.0无数据库版', '678829a2b00d4f94b2f9755132883df7', null, '20', '100', 'http://pan.baidu.com/s/1slLDMsl');
INSERT INTO `Pls_ShopSku` VALUES ('fefac66ab383418fa00ce2b546db7127', '2016-12-19 11:48:48.269822', '0', null, 'V3.0项目版', '678829a2b00d4f94b2f9755132883df7', null, '99.99', '500', 'http://pan.baidu.com/s/1qYtWFjI');

-- ----------------------------
-- Table structure for Pls_User
-- ----------------------------
DROP TABLE IF EXISTS `Pls_User`;
CREATE TABLE `Pls_User` (
  `user_id` varchar(127) NOT NULL,
  `createtime` datetime(6) NOT NULL,
  `disable` int(11) NOT NULL DEFAULT '0',
  `disabledesc` longtext,
  `last_time` datetime(6) NOT NULL,
  `row_number` longblob,
  `source_type` int(11) NOT NULL DEFAULT '1',
  `user_activation` int(11) NOT NULL DEFAULT '1',
  `user_code` varchar(10) NOT NULL,
  `user_email` varchar(64) DEFAULT NULL,
  `user_gender` int(11) NOT NULL DEFAULT '0',
  `user_image` longtext,
  `user_ip` varchar(32) DEFAULT NULL,
  `user_name` varchar(32) DEFAULT NULL,
  `user_phone` varchar(32) DEFAULT NULL,
  `user_pwd` varchar(32) NOT NULL,
  `user_visit` int(11) NOT NULL DEFAULT '1',
  `full_name` varchar(32) DEFAULT NULL,
  PRIMARY KEY (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of Pls_User
-- ----------------------------
INSERT INTO `Pls_User` VALUES ('66dbea2b41dd47a1a81eef2e5dc2af0e', '2016-09-01 12:56:49.861372', '0', null, '2017-03-13 21:43:39.884679', null, '2', '0', '#2468', 'hyl934532778@live.cn', '1', 'http://images.chuxinm.com/user/20161216112038137_3042.png', '127.0.0.1', 'admin', '18658152123', '14e1b600b1fd579f47433b88e8d85291', '0', 'admin');
INSERT INTO `Pls_User` VALUES ('cc64df824a6747e09ceb4aa926fed05a', '2016-11-13 10:50:29.501156', '0', null, '2017-03-13 14:36:44.707867', null, '1', '0', '#4788', 'test@qq.com', '2', 'http://images.chuxinm.com/user/20161217004016807_158297.jpg', '127.0.0.1', '测试用', '15097053876', '903bf1a0cf9451df92cb98685ea7b1ae', '0', '升水');

-- ----------------------------
-- Table structure for Pls_User_Apply
-- ----------------------------
DROP TABLE IF EXISTS `Pls_User_Apply`;
CREATE TABLE `Pls_User_Apply` (
  `apply_id` varchar(127) NOT NULL,
  `apply_desc` varchar(100) DEFAULT NULL,
  `apply_reason` varchar(100) DEFAULT NULL,
  `createtime` datetime(6) NOT NULL,
  `detail_id` varchar(64) DEFAULT NULL,
  `is_true` bit(1) NOT NULL DEFAULT b'0',
  `row_number` longblob,
  `user_id` varchar(64) DEFAULT NULL,
  PRIMARY KEY (`apply_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of Pls_User_Apply
-- ----------------------------
INSERT INTO `Pls_User_Apply` VALUES ('201453901af84cef811d486340815e21', '同意', '测试用户的申请~', '2016-12-15 10:51:38.037560', '66dbea2b41dd47a1a81eef2e5dc2af0e', '', null, 'cc64df824a6747e09ceb4aa926fed05a');
INSERT INTO `Pls_User_Apply` VALUES ('bc07cfa1e5764e41947c70aeba452d18', '同意', '超级管理员', '2016-12-14 16:57:12.980221', '66dbea2b41dd47a1a81eef2e5dc2af0e', '', null, '3df54864a8f840eda06e9eda00e7134d');
INSERT INTO `Pls_User_Apply` VALUES ('e1662a44703b46959e5f14f8c3051dbd', '同意', '超级管理员', '2016-12-14 16:56:05.238270', '66dbea2b41dd47a1a81eef2e5dc2af0e', '', null, '66dbea2b41dd47a1a81eef2e5dc2af0e');

-- ----------------------------
-- Table structure for Pls_User_ButtonAction
-- ----------------------------
DROP TABLE IF EXISTS `Pls_User_ButtonAction`;
CREATE TABLE `Pls_User_ButtonAction` (
  `userbutton_id` varchar(127) NOT NULL,
  `action_id` varchar(64) NOT NULL,
  `row_number` longblob,
  `user_id` varchar(64) NOT NULL,
  PRIMARY KEY (`userbutton_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of Pls_User_ButtonAction
-- ----------------------------

-- ----------------------------
-- Table structure for Pls_User_Department
-- ----------------------------
DROP TABLE IF EXISTS `Pls_User_Department`;
CREATE TABLE `Pls_User_Department` (
  `userdepartment_id` varchar(127) NOT NULL,
  `department_id` varchar(64) NOT NULL,
  `row_number` longblob,
  `user_id` varchar(64) NOT NULL,
  PRIMARY KEY (`userdepartment_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of Pls_User_Department
-- ----------------------------
INSERT INTO `Pls_User_Department` VALUES ('36cb4d007bcf4463bd9821eb6fef1ae4', 'f5f8040c0b7d494a848a20c623c11565', null, '66dbea2b41dd47a1a81eef2e5dc2af0e');

-- ----------------------------
-- Table structure for Pls_User_Role
-- ----------------------------
DROP TABLE IF EXISTS `Pls_User_Role`;
CREATE TABLE `Pls_User_Role` (
  `userrole_id` varchar(127) NOT NULL,
  `role_id` varchar(54) NOT NULL,
  `row_number` longblob,
  `user_id` varchar(54) NOT NULL,
  PRIMARY KEY (`userrole_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of Pls_User_Role
-- ----------------------------
INSERT INTO `Pls_User_Role` VALUES ('034775fc74674dd1a1fb8e0eed083c5b', '675d1215b42d423995f82f3abf48818c', null, '66dbea2b41dd47a1a81eef2e5dc2af0e');
INSERT INTO `Pls_User_Role` VALUES ('b690856f22e340668cec2e049b103718', 'f54be3bd06bc4b2798d823b933538cb6', null, 'cc64df824a6747e09ceb4aa926fed05a');
INSERT INTO `Pls_User_Role` VALUES ('e00d0e7c7c844851bb95e3ce93e5232d', 'f54be3bd06bc4b2798d823b933538cb6', null, '7f5a549ddfef4f05b826fdb2c65e230e');

-- ----------------------------
-- Table structure for Pls_UserInfo
-- ----------------------------
DROP TABLE IF EXISTS `Pls_UserInfo`;
CREATE TABLE `Pls_UserInfo` (
  `userinfo_id` varchar(127) NOT NULL,
  `address` varchar(640) DEFAULT NULL,
  `birthday` datetime(6) DEFAULT NULL,
  `city` int(11) DEFAULT NULL,
  `country` int(11) DEFAULT NULL,
  `direction_id` int(11) DEFAULT NULL,
  `province` int(11) DEFAULT NULL,
  `row_number` longblob,
  `user_id` varchar(64) NOT NULL,
  `zodiac` varchar(8) DEFAULT NULL,
  PRIMARY KEY (`userinfo_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of Pls_UserInfo
-- ----------------------------
INSERT INTO `Pls_UserInfo` VALUES ('d6db12c728a1485eb868160ab3e115ae', null, null, null, null, null, null, null, '66dbea2b41dd47a1a81eef2e5dc2af0e', null);
INSERT INTO `Pls_UserInfo` VALUES ('fe456303a3244479a6e285c1bc6aaada', null, null, null, null, null, null, null, 'cc64df824a6747e09ceb4aa926fed05a', null);

-- ----------------------------
-- View structure for Pls_ViewLeftJoinDepRole
-- ----------------------------
DROP VIEW IF EXISTS `Pls_ViewLeftJoinDepRole`;
CREATE ALGORITHM=UNDEFINED DEFINER=`chuxin`@`%` SQL SECURITY DEFINER VIEW `Pls_ViewLeftJoinDepRole` AS select `user`.`user_id` AS `user_id`,`user`.`user_name` AS `user_name`,`user`.`user_code` AS `user_code`,`user`.`full_name` AS `full_name`,`user`.`user_email` AS `user_email`,`user`.`user_phone` AS `user_phone`,`user`.`user_gender` AS `user_gender`,`user`.`user_activation` AS `user_activation`,`user`.`user_visit` AS `user_visit`,`user`.`user_ip` AS `user_ip`,`user`.`source_type` AS `source_type`,`user`.`user_image` AS `user_image`,`user`.`createtime` AS `createtime`,`user`.`disable` AS `disable`,`user`.`disabledesc` AS `disabledesc`,`user`.`last_time` AS `last_time`,`department`.`department_name` AS `department_name`,`department`.`department_id` AS `department_id`,`role`.`role_name` AS `role_name`,`role`.`role_id` AS `role_id` from ((((`Pls_User` `user` left join `Pls_User_Department` `userleftdepart` on((`user`.`user_id` = `userleftdepart`.`user_id`))) left join `Pls_Department` `department` on((`userleftdepart`.`department_id` = `department`.`department_id`))) left join `Pls_User_Role` `userleftrole` on((`user`.`user_id` = `userleftrole`.`user_id`))) left join `Pls_Role` `role` on((`userleftrole`.`role_id` = `role`.`role_id`))) ;

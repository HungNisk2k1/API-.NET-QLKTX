import {
  FileOutlined,
  UserOutlined,
  DesktopOutlined,
  CarOutlined,
  DollarOutlined,
  LogoutOutlined,
} from "@ant-design/icons";
import React from "react";
import { Layout, Menu } from "antd";
import { useState } from "react";
import "./CssMenu.css";
import { Link } from "react-router-dom";
const { Sider } = Layout;
function getItem(label, key, icon, children) {
  return {
    key,
    icon,
    children,
    label,
  };
}
const items = [
  getItem(
    <Link to="/sinh-vien">Quản Lý Sinh Viên</Link>,
    "1",
    <UserOutlined />
  ),
  getItem(
    <Link to="/phong-tro">Quản Lý Phòng Trọ</Link>,
    "2",
    <DesktopOutlined />
  ),
  getItem(
    <Link to="/tien-tro">Quản Lý Chi Phí</Link>,
    "3",
    <DollarOutlined />
  ),
  getItem(<Link to="/gui-xe">Quản Lý Gửi Xe</Link>, "4", <CarOutlined />),
  // getItem(<Link to="/ho-tro">Yêu Cầu Hỗ Trợ</Link>, "5", <FileOutlined />),
  getItem("Hành Động", "6", <DesktopOutlined />, [
    getItem(
      <Link to="tai-khoan">Người Quản Lý</Link>,
      "sub7",
      <FileOutlined />
    ),
    getItem("Đặng Xuất", "sub8", <LogoutOutlined />),
  ]),
];
const rootSubmenuKeys = ["1", "2", "3", "4", "5", "6"];
function MenuPage(props) {
  const [openKeys, setOpenKeys] = React.useState(["sub1"]);

  const onOpenChange = (keys) => {
    const latestOpenKey = keys.find((key) => openKeys.indexOf(key) === -1);

    if (rootSubmenuKeys.indexOf(latestOpenKey) === -1) {
      setOpenKeys(keys);
    } else {
      setOpenKeys(latestOpenKey ? [latestOpenKey] : []);
    }
  };
  const [collapsed, setCollapsed] = useState(false);
  return (
    <Layout
      style={{
        minHeight: "100vh",
      }}
    >
      <Sider
        collapsible
        collapsed={collapsed}
        onCollapse={(value) => setCollapsed(value)}
      >
        <h2
          style={{
            paddingTop: "20px",
            textAlign: "center",
            fontSize: "11px",
            marginBottom: "-55px",
            color: "#6777EF",
          }}
        >
          QUẢN LÝ KÝ TÚC XÁ
        </h2>
        <div
          style={{
            height: 32,
            margin: 16,
            background: "rgba(255, 255, 255, 0.2)",
          }}
        />
        <Menu
          theme="dark"
          openKeys={openKeys}
          onOpenChange={onOpenChange}
          mode="inline"
          items={items}
        />
      </Sider>
    </Layout>
  );
}

export default MenuPage;

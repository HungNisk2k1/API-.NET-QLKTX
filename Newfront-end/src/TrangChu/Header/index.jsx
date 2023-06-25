import { UserOutlined } from "@ant-design/icons";
import "./CssHome.css";
import { Layout } from "antd";
const { Header } = Layout;

const HeaderPage = () => {
  return (
    <Layout>
      <Layout className="site-layout">
        <Header
          style={{
            padding: 0,
            background: "#6777EF",
            textAlign: "right",
            paddingRight: "20px",
            color: "white",
            fontWeight: "bold",
          }}
        >
          <UserOutlined
            style={{
              width: "40px",
            }}
          />{" "}
          Hi, Quản Trị Viên
        </Header>
      </Layout>
    </Layout>
  );
};

export default HeaderPage;

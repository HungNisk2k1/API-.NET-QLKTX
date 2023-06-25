import { Breadcrumb, Layout, Button, Table } from "antd";
import { useState } from "react";
import { Outlet } from "react-router-dom";
const { Content } = Layout;

const ContentPage = () => {
  return (
    <Layout
      style={{
        minWidth: "100vh",
      }}
    >
      <Layout className="site-layout">
        <Content
          style={{
            margin: "0 16px",
          }}
        >
          {/* <Breadcrumb
            style={{
              margin: "16px 0",
            }}
          >
            <div
              style={{
                marginTop: "-30px",
                display: "flex",
                alignItems: "center",
                width: "100%",
                height: "50px",
                background: "white",
                paddingLeft: "10px",
                borderRadius: "5px",
              }}
            >
              Thông Tin Tài Khoản
            </div>
          </Breadcrumb> */}

          <div
            style={{
              padding: 24,
              minHeight: 360,
              background: "white",
              borderRadius: "5px",
            }}
          >
            <Outlet />
          </div>
        </Content>
      </Layout>
    </Layout>
  );
};
export default ContentPage;

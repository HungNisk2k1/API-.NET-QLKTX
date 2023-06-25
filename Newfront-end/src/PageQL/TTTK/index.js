import React from "react";
import "./CssTTTK.css";
import { UserOutlined } from "@ant-design/icons";
import { Breadcrumb } from "antd";
function index(props) {
  return (
    <div>
      <Breadcrumb
        style={{
          margin: "16px 0",
        }}
      >
        <div
          style={{
            marginTop: "-56px",
            display: "flex",
            alignItems: "center",
            width: "100%",
            height: "50px",
            background: "white",
            paddingLeft: "10px",
            borderRadius: "5px",
            boxShadow: " 3px 3px 6px #6777EF",
            fontWeight: "bold",
            color: "rgb(103, 119, 239)",
          }}
        >
          <UserOutlined style={{ width: "50px" }} />
          THÔNG TIN NGƯỜI QUẢN LÝ
        </div>
      </Breadcrumb>
      <div style={{ display: "flex" }}>
        <div>
          <table border={0}>
            <tr>
              <td
                style={{
                  width: "200px",
                  height: "40px",
                  fontWeight: "bold",
                  color: "rgb(103, 119, 239)",
                }}
              >
                Họ Và Tên
              </td>
              <td>:</td>
              <td>Đặng Thị Trà My </td>
            </tr>
            <tr>
              <td
                style={{
                  width: "200px",
                  height: "40px",
                  fontWeight: "bold",
                  color: "rgb(103, 119, 239)",
                }}
              >
                Mã Quản Lý
              </td>
              <td>:</td>
              <td>2000170 </td>
            </tr>
            <tr>
              <td
                style={{
                  width: "200px",
                  height: "40px",
                  fontWeight: "bold",
                  color: "rgb(103, 119, 239)",
                }}
              >
                Ngày Sinh
              </td>
              <td>:</td>
              <td>27/05/2002 </td>
            </tr>
            <tr>
              <td
                style={{
                  width: "200px",
                  height: "40px",
                  fontWeight: "bold",
                  color: "rgb(103, 119, 239)",
                }}
              >
                Địa Chỉ
              </td>
              <td>:</td>
              <td>Lạng Sơn </td>
            </tr>
            <tr>
              <td
                style={{
                  width: "200px",
                  height: "40px",
                  fontWeight: "bold",
                  color: "rgb(103, 119, 239)",
                }}
              >
                Liên Hệ
              </td>
              <td>:</td>
              <td>. . . </td>
            </tr>
            <tr>
              <td
                style={{
                  width: "200px",
                  height: "40px",
                  fontWeight: "bold",
                  color: "rgb(103, 119, 239)",
                }}
              >
                Ngày Tiếp Nhận Quản Lý
              </td>
              <td>:</td>
              <td>25/03/2023 </td>
            </tr>
          </table>
        </div>
        <div className="table1" style={{ marginLeft: "10px" }}>
          <table border={0}>
            <tr>
              <td
                style={{
                  width: "200px",
                  height: "40px",
                  fontWeight: "bold",
                  color: "rgb(103, 119, 239)",
                }}
              >
                Họ Và Tên
              </td>
              <td>:</td>
              <td>Ngô Văn Phi </td>
            </tr>
            <tr>
              <td
                style={{
                  width: "200px",
                  height: "40px",
                  fontWeight: "bold",
                  color: "rgb(103, 119, 239)",
                }}
              >
                Mã Quản Lý
              </td>
              <td>:</td>
              <td>2000223 </td>
            </tr>
            <tr>
              <td
                style={{
                  width: "200px",
                  height: "40px",
                  fontWeight: "bold",
                  color: "rgb(103, 119, 239)",
                }}
              >
                Ngày Sinh
              </td>
              <td>:</td>
              <td>17/02/2002 </td>
            </tr>
            <tr>
              <td
                style={{
                  width: "200px",
                  height: "40px",
                  fontWeight: "bold",
                  color: "rgb(103, 119, 239)",
                }}
              >
                Địa Chỉ
              </td>
              <td>:</td>
              <td>Vĩnh Phúc </td>
            </tr>
            <tr>
              <td
                style={{
                  width: "200px",
                  height: "40px",
                  fontWeight: "bold",
                  color: "rgb(103, 119, 239)",
                }}
              >
                Liên Hệ
              </td>
              <td>:</td>
              <td>. . . </td>
            </tr>
            <tr>
              <td
                style={{
                  width: "200px",
                  height: "40px",
                  fontWeight: "bold",
                  color: "rgb(103, 119, 239)",
                }}
              >
                Ngày Tiếp Nhận Quản Lý
              </td>
              <td>:</td>
              <td>25/03/2023 </td>
            </tr>
          </table>
        </div>
        <div className="table1" style={{ marginLeft: "10px" }}>
          <table border={0}>
            <tr>
              <td
                style={{
                  width: "200px",
                  height: "40px",
                  fontWeight: "bold",
                  color: "rgb(103, 119, 239)",
                }}
              >
                Họ Và Tên
              </td>
              <td>:</td>
              <td>Chu Xuân Việt </td>
            </tr>
            <tr>
              <td
                style={{
                  width: "200px",
                  height: "40px",
                  fontWeight: "bold",
                  color: "rgb(103, 119, 239)",
                }}
              >
                Mã Quản Lý
              </td>
              <td>:</td>
              <td>2000023 </td>
            </tr>
            <tr>
              <td
                style={{
                  width: "200px",
                  height: "40px",
                  fontWeight: "bold",
                  color: "rgb(103, 119, 239)",
                }}
              >
                Ngày Sinh
              </td>
              <td>:</td>
              <td>21/08/2002 </td>
            </tr>
            <tr>
              <td
                style={{
                  width: "200px",
                  height: "40px",
                  fontWeight: "bold",
                  color: "rgb(103, 119, 239)",
                }}
              >
                Địa Chỉ
              </td>
              <td>:</td>
              <td>Hà Nội </td>
            </tr>
            <tr>
              <td
                style={{
                  width: "200px",
                  height: "40px",
                  fontWeight: "bold",
                  color: "rgb(103, 119, 239)",
                }}
              >
                Liên Hệ
              </td>
              <td>:</td>
              <td>. . . </td>
            </tr>
            <tr>
              <td
                style={{
                  width: "200px",
                  height: "40px",
                  fontWeight: "bold",
                  color: "rgb(103, 119, 239)",
                }}
              >
                Ngày Tiếp Nhận Quản Lý
              </td>
              <td>:</td>
              <td>25/03/2023 </td>
            </tr>
          </table>
        </div>
      </div>
    </div>
  );
}

export default index;

import { Layout } from "antd";
import "../Footer/CssFooter.css";
const { Footer } = Layout;

const FooterPage = () => {
  return (
    <Layout
    // style={{
    //   minHeight: "100vh",
    // }}
    >
      <Layout className="site-layout">
        <Footer
          style={{
            textAlign: "center",
            color: "rgb(103, 119, 239)",
            fontFamily: "verdana",
          }}
        >
          <div id="footer">
            <div id="f0">
              <div id="f1">
                <h3>KÝ TÚC XÁ - GROUP 9</h3>
                <br />
                <p>
                  {" "}
                  <span>Địa chỉ:</span> Lai xá, Kim Chung, Hoài Đức Hà Nội
                </p>
                <p>
                  <span>Hotline & zalo:</span> 09.XXXX.XXXX
                </p>
                <p>
                  <span>Email:</span> Group9@gmail.com
                </p>
                {/* <p>
                  <span>Youtube:</span>  KTX
                </p> */}
              </div>
              <div id="f2">
                <h3>TIN TỨC & QUY ĐỊNH</h3>
                <br />
                <p>
                  <a href="./page_gt.html"> Tin tức hàng ngày</a>
                </p>
                <p>
                  <a href="./page_gt.html"> Quy tắc ký túc xá</a>
                </p>
                <p>
                  <a href="./page_gt.html"> Đời sống ký túc xá</a>
                </p>
              </div>
              <div id="f3">
                <h3>THANH TOÁN</h3>
                <br />
                <p>
                  <span>STK:</span> Quản Lý KTX G9
                </p>
                <p>
                  <span>MB:</span> 9999.9999.9999.9999
                </p>
                <p>
                  <span>VTB:</span> 9999.9999.9999.9999
                </p>
              </div>
            </div>
          </div>
          <p style={{ padding: "20px" }}>
            <b>G9 ©2023 Created By Group 9</b>{" "}
          </p>
        </Footer>
      </Layout>
    </Layout>
  );
};

export default FooterPage;

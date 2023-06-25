import { useEffect, useState } from "react";
import {
  EditOutlined,
  DeleteOutlined,
  ExclamationCircleFilled,
} from "@ant-design/icons";
import React from 'react';
import { Breadcrumb, Layout, Menu, theme } from "antd";
import { Space,Button,Table,Modal,Status, message} from 'antd';
import axios from "axios";
import ModalChoPhi from "./modal";
import { TeamOutlined } from "@ant-design/icons";
const{ Content } =Layout; 
const { confirm } = Modal;


function QL_PhongTro(props){
  const[DanhSachChiPhi, setDanhSachChiPhi] = useState();
  const [visibleModal, setvisibleModal] = useState(false);
  const[Action,setAction]=useState();
  const [DataEdit,setDataEdit]= useState();
  async function getDanhSachChiPhi(){
    await axios  
    .get("https://localhost:7188/api/v1/QLChiPhi/DanhSach")
    .then((res) =>{
      const dataChiPhi = res.data.Data;
      setDanhSachChiPhi(dataChiPhi);
    } )
    .catch((error) =>{
      console.log(error);
    });
  }
  async function themChiPhi(dataChiPhi){
    await axios  
    .post("https://localhost:7188/api/v1/QLChiPhi/ThemMoi",dataChiPhi)//link api them mới sinh viên
    .then((res) =>{
        if(res.data.Status=1){
          message.success(res.data.Message)
        }
        else{
          message.error(res.data.Message)
        }
    } )
    .catch((error) =>{
      console.log(error);
    });
  }
  async function suaChiPhi(dataChiPhi){
    await axios  
    .post("https://localhost:7188/api/v1/QLChiPhi/CapNhat",dataChiPhi)//link api sua sinh viên
    .then((res) =>{
        if(res.data.Status=1){
          message.success(res.data.Message)
        }
        else{
          message.error(res.data.Message)
        }
    } )
    .catch((error) =>{
      console.log(error);
    });
  }
  async function xoaChiPhi(MaSV){
    await axios  
    .post(`https://localhost:7188/api/v1/QLChiPhi/Xoa?MaSV=${MaSV}`)//link api xoa sinh viên
    .then((res) =>{
        if(res.data.Status==1){
          message.success(res.data.Message);
           getDanhSachChiPhi();
        }
        else{
          message.error(res.data.Message)
        }
    } )
    .catch((error) =>{
      console.log(error);
    });
  }
  useEffect(() =>{
    getDanhSachChiPhi();
  }, []);
  const columns = [
    {
      title:'STT',
      render:(_,record,index)=>index+1,
    },
    {
      title: "Mã Sinh Viên",
      dataIndex: "MaSV",
    },
    {
      title: "Ngày Đăng Ký",
      dataIndex: "NgayDK",
    },
    {
      title: "Ngày Nộp Tiền",
      dataIndex: "NgayNopTien",
    },
    {
      title: "Trạng Thái",
      dataIndex: "TrangThai",
    },
    {
      title: "Thao tác",
      align: "center",
      border: "1px solid #f0f0f0",
      width: "100px",
      render: (_, record) => renderThaoTac(record),
     }
  ];

  function renderThaoTac(record) {
    return (
      <div>
        <EditOutlined
          style={{ fontSize: "18px", cursor: "pointer", marginRight: "10px" }}
          onClick={()=> showEdit(record)}
        />
        <DeleteOutlined
          style={{ fontSize: "18px", cursor: "pointer" }}
          // onClick={() => showDeleteConfirm(record.id_QLCP)}
          onClick={() => showDeleteConfirm(record.MaSV)}

        />
      </div>
    );
  }
  function showAdd(){
    setvisibleModal(true);
    setAction("add");
    setDataEdit(null)
  }
  function showEdit(record){
    setvisibleModal(true);
    setAction("edit");
    setDataEdit(record);
  }
  function showDeleteConfirm(MaSV){
  // function showDeleteConfirm(id){

    confirm({
      title:"Cảnh Báo",
      icon:<ExclamationCircleFilled />,
      content:"Bạn có muốn xóa bản ghi này",
      okText:"Có",
      cancelText:"Không",
      onOk(){
        xoaChiPhi(MaSV);
        // xoaChiPhi(id);

      },
    });
  }
  function hiddenModal(){
    setvisibleModal(false);
  }
  async function Save(dataChiPhi){
    //kiểm tra action == add thì thực hiện gọi api  thêm mới
if(Action=="add"){
   await themChiPhi(dataChiPhi);
}
    //kiểm tra action == edit thì thực hiện gọi api  sửa
    else{
   await suaChiPhi(dataChiPhi);
    }
    await getDanhSachChiPhi();
  }

  return (
    <div>
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
            <TeamOutlined style={{width:"50px"}}/> QUẢN LÝ CHI PHÍ
          </div>
        </Breadcrumb>
      </div>
      <div
        style={{
          marginBottom: 16,
        }}
      >
        <Button
          type="primary"
        onClick={() => showAdd()}
        >
          Thêm Mới
        </Button>  
      </div>

      <Table dataSource={DanhSachChiPhi} 
      columns={columns} 
      // rowKey={(record) => record.id} bordered 
      rowKey={(record) => record.MaSV} bordered 

      />
      <ModalChoPhi 
       visible={visibleModal}
       hiddenModal={hiddenModal}
       action={Action}
       dataEdit={DataEdit}
       save={Save}
       ></ModalChoPhi>
    </div>
  );
};

export default QL_PhongTro;

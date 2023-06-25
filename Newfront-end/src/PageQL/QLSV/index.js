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
import ModalSinhVien from "./modal";
import { TeamOutlined } from "@ant-design/icons";
const{ Content } =Layout;
const { confirm } = Modal;


function QL_SinhVien(props){
  const[DanhSachSinhVien, setDanhSachSinhVien] = useState();
  const [visibleModal, setvisibleModal] = useState(false);
  const[Action,setAction]=useState();
  const [DataEdit,setDataEdit]= useState();
  async function getDanhSachSinhVien(){
    await axios  
    .get("https://localhost:7188/api/v1/SinhVien/DanhSach")
    .then((res) =>{
      const dataSinhVien = res.data.Data;
      setDanhSachSinhVien(dataSinhVien);
    } )
    .catch((error) =>{
      console.log(error);
    });
  }
  async function themMoiSinhVien(dataSinhVien){
    await axios  
    .post("https://localhost:7188/api/v1/SinhVien/ThemMoi",dataSinhVien)//link api them mới sinh viên
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
  async function suaSinhVien(dataSinhVien){
    await axios  
    .post("https://localhost:7188/api/v1/SinhVien/CapNhat",dataSinhVien)//link api sua sinh viên
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
  async function xoaSinhVien(MaSV){
    await axios  
    .post(`https://localhost:7188/api/v1/SinhVien/Xoa?MaSV=${MaSV}`)//link api xoa sinh viên
    .then((res) =>{
        if(res.data.Status=1){
          message.success(res.data.Message);
           getDanhSachSinhVien();
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
    getDanhSachSinhVien();
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
      title: "Họ Và Tên",
      dataIndex: "HoTenSV",
    },
    {
      title: "Ngày Sinh",
      dataIndex: "NgaySinh",
    },
    {
      title: "Địa Chỉ",
      dataIndex: "DiaChi",
    },
    {
      title: "Phòng",
      dataIndex: "Phong",
    },
    {
      title: "Liên Hệ",
      dataIndex: "SDT",
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
    confirm({
      title:"Cảnh Báo",
      icon:<ExclamationCircleFilled />,
      content:"Bạn có muốn xóa bản ghi này",
      okText:"Có",
      cancelText:"Không",
      onOk(){
        xoaSinhVien(MaSV);
      },
    });
  }
  function hiddenModal(){
    setvisibleModal(false);
  }
  async function Save(dataSinhVien){
    //kiểm tra action == add thì thực hiện gọi api  thêm mới
if(Action=="add"){
   await themMoiSinhVien(dataSinhVien);
}
    //kiểm tra action == edit thì thực hiện gọi api  sửa
    else{
   await suaSinhVien(dataSinhVien);
    }
    await getDanhSachSinhVien();
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
            <TeamOutlined style={{width:"50px"}}/> QUẢN LÝ SINH VIÊN
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

      <Table dataSource={DanhSachSinhVien} 
      columns={columns} 
      rowKey={(record) => record.MaSV} bordered 
      />
      <ModalSinhVien 
       visible={visibleModal}
       hiddenModal={hiddenModal}
       action={Action}
       dataEdit={DataEdit}
       save={Save}
       ></ModalSinhVien>
    </div>
  );
};

export default QL_SinhVien;

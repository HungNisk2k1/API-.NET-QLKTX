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
import ModalPhongTro from "./modal";
import { TeamOutlined } from "@ant-design/icons";
const{ Content } =Layout; 
const { confirm } = Modal;


function QL_PhongTro(props){
  const[DanhSachPhongTro, setDanhSachPhongTro] = useState();
  const [visibleModal, setvisibleModal] = useState(false);
  const[Action,setAction]=useState();
  const [DataEdit,setDataEdit]= useState();
  async function getDanhSachPhongTro(){
    await axios  
    .get("https://localhost:7188/api/v1/Phong/DanhSach")
    .then((res) =>{
      const dataPhongTro = res.data.Data;
      setDanhSachPhongTro(dataPhongTro);
    } )
    .catch((error) =>{
      console.log(error);
    });
  }
  async function themMoiPhongTro(dataPhongTro){
    await axios  
    .post("https://localhost:7188/api/v1/Phong/ThemMoi",dataPhongTro)//link api them mới sinh viên
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
  async function suaPhongTro(dataPhongTro){
    await axios  
    .post("https://localhost:7188/api/v1/Phong/CapNhat",dataPhongTro)//link api sua sinh viên
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
  async function xoaPhongTro(id_Phong){
    await axios  
    .post(`https://localhost:7188/api/v1/Phong/Xoa?id_Phong=${id_Phong}`)//link api xoa sinh viên
    .then((res) =>{
        if(res.data.Status=1){
          message.success(res.data.Message);
           getDanhSachPhongTro();
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
    getDanhSachPhongTro();
  }, []);
  const columns = [
    {
      title:'STT',
      render:(_,record,index)=>index+1,
    },
    {
      title: "ID Phòng",
      dataIndex: "id_Phong",
    },
    {
      title: "Phòng",
      dataIndex: "Phong",
    },
   
    {
      title: "Giá Phòng",
      dataIndex: "GiaPhong",
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
          onClick={() => showDeleteConfirm(record.id_Phong)}
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
  function showDeleteConfirm(id_Phong){
    confirm({
      title:"Cảnh Báo",
      icon:<ExclamationCircleFilled />,
      content:"Bạn có muốn xóa bản ghi này",
      okText:"Có",
      cancelText:"Không",
      onOk(){
        xoaPhongTro(id_Phong);
      },
    });
  }
  function hiddenModal(){
    setvisibleModal(false);
  }
  async function Save(dataPhongTro){
    //kiểm tra action == add thì thực hiện gọi api  thêm mới
if(Action=="add"){
   await themMoiPhongTro(dataPhongTro);
}
    //kiểm tra action == edit thì thực hiện gọi api  sửa
    else{
   await suaPhongTro(dataPhongTro);
    }
    await getDanhSachPhongTro();
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
            <TeamOutlined style={{width:"50px"}}/> QUẢN LÝ PHÒNG TRỌ
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

      <Table dataSource={DanhSachPhongTro} 
      columns={columns} 
      rowKey={(record) => record.id_Phong} bordered 
      />
      <ModalPhongTro 
       visible={visibleModal}
       hiddenModal={hiddenModal}
       action={Action}
       dataEdit={DataEdit}
       save={Save}
       ></ModalPhongTro>
    </div>
  );
};

export default QL_PhongTro;

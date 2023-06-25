import axios from "axios"

const server = "https://localhost:7188/api"

export default {
    login: server + 'TaiKhoan/Login',

    danhsachGuiXe: server + 'v1/GuiXe/DanhSach',
    chitietGuiXe: server + 'v1/GuiXe/ChiTiet',
    themmoiGuiXe: server + 'v1/GuiXe/ThemMoi',
    capnhatGuiXe: server + 'v1/GuiXe/CapNhap',
    xoaBacGuiXe: server + 'v1/GuiXe/Xoa?MaSV=',

    danhsachPhong: server + 'v1/Phong/DanhSach',
    chitietPhong: server + 'v1/Phong/ChiTiet',
    themmoiPhong: server + 'v1/Phong/ThemMoi',
    capnhatPhong: server + 'v1/Phong/CapNhat',
    xoaPhong: server + 'v1/Phong/Xoa?id_Phong=',

    danhsachQLChiPhi: server + 'v1/QLChiPhi/DanhSach',
    chitietQLChiPhi: server + 'v1/QLChiPhi/ChiTiet',
    themmoiQLChiPhi: server + 'v1/QLChiPhi/ThemMoi',
    capnhatQLChiPhi: server + 'v1/QLChiPhi/CapNhat',
    xoaQLChiPhi: server + 'v1/QLChiPhi/Xoa?MaSV=',

    danhsachSinhVien: server + 'v1/SinhVien/DanhSach',
    chitietSinhVien: server + 'v1/SinhVien/ChiTiet',
    themmoiSinhVien: server + 'v1/SinhVien/ThemMoi',
    capnhatSinhVien: server + 'v1/SinhVien/CapNhat',
    xoaSinhVien: server + 'v1/SinhVien/Xoa?MaSV=',

    Login: async function (payload) {
        let res = await axios.post(this.login, payload)
        return res
    },
    // Danh sách Gửi xe
    DanhSachGuiXe: async function (payload) {
        let res = await axios.get(this.danhsachGuiXe, payload)
        return res
    },
    ChiTietGuiXe: async function (payload) {
        let res = await axios.get(this.chitietGuiXe, payload)
        return res
    },
    ThemMoiGuiXe: async function (payload) {
        let res = await axios.post(this.themmoiGuiXe, payload)
        return res
    },
    CapNhatGuiXe: async function (payload) {
        let res = await axios.put(this.capnhatGuiXe, payload)
        return res
    },
    XoaGuiXe: async function (payload) {
        let res = await axios.delete(this.xoaGuiXe + payload)
        return res
    },

    // Danh sách Phòng
    DanhSachPhong: async function (payload) {
        let res = await axios.get(this.danhsachPhong, payload)
        return res
    },
    ChiTietPhong: async function (payload) {
        let res = await axios.get(this.chitietPhong, payload)
        return res
    },
    ThemMoiPhong: async function (payload) {
        let res = await axios.post(this.themmoiPhong, payload)
        return res
    },
    CapNhatPhong: async function (payload) {
        let res = await axios.put(this.capnhatPhong, payload)
        return res
    },
    XoaPhong: async function (payload) {
        let res = await axios.delete(this.xoaPhong + payload)
        return res
    },


    // Danh sách Quản lý chi phí
   
    DanhSachQLChiPhi: async function (payload) {
        let res = await axios.get(this.danhsachQLChiPhi, payload)
        return res
    },
    ChiTietQLChiPhi: async function (payload) {
        let res = await axios.get(this.chitietQLChiPhi, payload)
        return res
    },
    ThemMoiQLChiPhi: async function (payload) {
        let res = await axios.post(this.themmoiQLChiPhi, payload)
        return res
    },
    CapNhatQLChiPhi: async function (payload) {
        let res = await axios.put(this.capnhatQLChiPhi, payload)
        return res
    },
    XoaQLChiPhi: async function (payload) {
        let res = await axios.delete(this.xoaQLChiPhi + payload)
        return res
    },

    // Danh sách Sinh viên
    DanhSachSinhVien: async function (payload) {
        let res = await axios.get(this.danhsachSinhVien, payload)
        return res
    },
    ChiTietSinhVien: async function (payload) {
        let res = await axios.get(this.chitietSinhVien, payload)
        return res
    },
    ThemMoiSinhVien: async function (payload) {
        let res = await axios.post(this.themmoiSinhVien, payload)
        return res
    },
    CapNhatSinhVien: async function (payload) {
        let res = await axios.put(this.capnhatSinhVien, payload)
        return res
    },
    XoaSinhVien: async function (payload) {
        let res = await axios.delete(this.xoaSinhVien + payload)
        return res
    },

}
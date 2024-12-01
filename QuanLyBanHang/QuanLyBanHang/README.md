Các bước cài đặt:
1. Copy truy vấn từ QLBHSQL.sql bên trong folder Data.
2. Dán truy vấn vào ssms tại new query.
3. Cơ sở dữ liệu có tên là QLBH2
4. Vào Visual Studio chọn Tools/Connect to database
5. Vào SSMS có cửa sổ kết nối hiện ra, copy phần server name rồi dán vào phần server name trong bước trên
6. Click vào ô trust server certificate
7. Chọn database QLBH2
8. Click test connection để xem kết nối đã thành công chưa
9. Nếu đã thành công, chọn advanced rồi copy connection string ở cuối cùng
10. Dán connection string vào biến connectionString trong App.config
	1. <connectionStrings>
		<add name="QLBHEntities"
			 connectionString="metadata=res://*/Model.csdl|res://*/Model.ssdl|res://*/Model.msl;provider=System.Data.SqlClient;provider connection string=&quot;datasource=THANHHA\SA;initial catalog=QLBH;integratedsecurity=True;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True;App=EntityFramework&quot;"
			 providerName="System.Data.EntityClient" />
	</connectionStrings>

Lưu ý: nếu connectionString bị lỗi, hãy dán tên server của sql server vào connectionString thay thế cho tên server ở trong source code.
Tên đăng nhập mặc định truy cập là admin và mật khẩu là admin.

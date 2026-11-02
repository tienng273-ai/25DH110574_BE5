BE 5 - CUSTOMER SITE (ASP.NET MVC 5 + Entity Framework 6)

1. YEU CAU
- Windows + Visual Studio 2019/2022
- ASP.NET and web development workload
- .NET Framework 4.8 Developer Pack
- SQL Server LocalDB (hoac SQL Server Express/SQL Server)

2. TAO DATABASE
- Mo SQL Server Management Studio.
- Tao database ten MyStore.
- Chay file Database_MyStore.sql trong thu muc Database.
- Neu dung SQL Server khac LocalDB, sua Data Source trong Web.config.

3. MO PROJECT
- Mo BE5_CustomerSite.sln bang Visual Studio.
- Chuot phai Solution > Restore NuGet Packages.
- Kiem tra connection string MyStoreEntities trong Web.config.
- Build > Build Solution, sau do nhan F5.

4. DU LIEU
Database script cua de bai chi tao bang, chua co san du lieu mau. De xem san pham tren Home va Product Detail, can them Category va Product, sau do co the them Order va OrderDetail de tao du lieu da ban.
Anh san pham luu trong Content/images; truong ProductImage luu duong dan tuong doi, vi du ~/Content/images/phone.jpg.

5. CHUC NANG TRONG BAI
- Metadata + Partial Class cho User, Customer, Category, Product, Order, OrderDetail.
- Data Annotation: Required, StringLength, Range, Display, EmailAddress, Phone, DataType.
- Home: banner, tim kiem ten/mo ta/danh muc, 10 san pham noi bat, danh sach toi da 20 san pham co luot ban thap, phan trang 6 san pham/trang.
- Product Detail: thong tin san pham, so luong da ban, chon so luong, tam tinh, them vao Session Cart, 8 san pham cung danh muc va 8 top deals cung danh muc.
- ProductList: xem danh sach san pham theo danh muc.

6. LUU Y
- Project dung Code First mapping truc tiep vao database MyStore co san, khong tu dong tao lai database.
- Neu bang Customer/User cua database hien tai co cau truc FK khac voi mapping, kiem tra lai FK_User_Customer trong SQL script truoc khi chay.
- Phan gio hang o bai nay chi them san pham vao Session va hien thi so luong tren menu; trang gio hang/thanh toan thuoc cac bai tiep theo.

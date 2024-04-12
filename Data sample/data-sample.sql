-- delete all data
delete from Breeds
go
delete from Colours
go
delete from DonorPetAudits
go
delete from DonorPets
go
delete from Donors
go
delete from Locations
go
delete from Owners
go
delete from PetAudits
go
delete from PetBreeds
go
delete from PetColours
go
delete from PetImages
go
delete from Pets
go
delete from RoleClaims
go
delete from UserLogins
go
delete from UserRoles
go
delete from Roles
go
delete from UserClaims
go
delete from UserTokens
go
delete from Users
go
delete from VolunteerAudits
go
delete from VolunteerRoles
go
delete from VolunteerRoleXVolunteers
go
delete from Volunteers
go


-- set default identity - đặt lại id thành 1
DBCC CHECKIDENT ('dbo.Breeds', RESEED, 0)
go
DBCC CHECKIDENT ('dbo.Colours', RESEED, 0)
go
DBCC CHECKIDENT ('dbo.DonorPetAudits', RESEED, 0)
go
DBCC CHECKIDENT ('dbo.DonorPets', RESEED, 0)
go
DBCC CHECKIDENT ('dbo.Donors', RESEED, 0)
go
DBCC CHECKIDENT ('dbo.Locations', RESEED, 0)
go
DBCC CHECKIDENT ('dbo.Owners', RESEED, 0)
go
DBCC CHECKIDENT ('dbo.PetAudits', RESEED, 0)
go
DBCC CHECKIDENT ('dbo.PetBreeds', RESEED, 0)
go
DBCC CHECKIDENT ('dbo.PetColours', RESEED, 0)
go
DBCC CHECKIDENT ('dbo.PetImages', RESEED, 0)
go
DBCC CHECKIDENT ('dbo.Pets', RESEED, 0)
go
DBCC CHECKIDENT ('dbo.RoleClaims', RESEED, 0)
go
DBCC CHECKIDENT ('dbo.UserLogins', RESEED, 0)
go
DBCC CHECKIDENT ('dbo.UserRoles', RESEED, 0)
go
DBCC CHECKIDENT ('dbo.Users', RESEED, 0)
go
DBCC CHECKIDENT ('dbo.UserClaims', RESEED, 0)
go
DBCC CHECKIDENT ('dbo.UserTokens', RESEED, 0)
go
DBCC CHECKIDENT ('dbo.VolunteerAudits', RESEED, 0)
go
DBCC CHECKIDENT ('dbo.VolunteerRoles', RESEED, 0)
go
DBCC CHECKIDENT ('dbo.VolunteerRoleXVolunteers', RESEED, 0)
go
DBCC CHECKIDENT ('dbo.Volunteers', RESEED, 0)
go

select * from Breeds

delete from Breeds


/* insert colours */
INSERT INTO Colours(ColourName, IsDeleted) VALUES ('Apricot', 0);
INSERT INTO Colours(ColourName, IsDeleted) VALUES ('Beige', 0);
INSERT INTO Colours(ColourName, IsDeleted) VALUES ('Bicolor', 0);
INSERT INTO Colours(ColourName, IsDeleted) VALUES ('Black', 0);
INSERT INTO Colours(ColourName, IsDeleted) VALUES ('Brindle', 0);
INSERT INTO Colours(ColourName, IsDeleted) VALUES ('Golden', 0);
INSERT INTO Colours(ColourName, IsDeleted) VALUES ('Brown', 0);
INSERT INTO Colours(ColourName, IsDeleted) VALUES ('Harlequin', 0);
INSERT INTO Colours(ColourName, IsDeleted) VALUES ('Merle', 0);
INSERT INTO Colours(ColourName, IsDeleted) VALUES ('Chestnut', 0);
INSERT INTO Colours(ColourName, IsDeleted) VALUES ('Red', 0);
INSERT INTO Colours(ColourName, IsDeleted) VALUES ('Orange', 0);
INSERT INTO Colours(ColourName, IsDeleted) VALUES ('Sable', 0);
INSERT INTO Colours(ColourName, IsDeleted) VALUES ('Tricolor', 0);
INSERT INTO Colours(ColourName, IsDeleted) VALUES ('White', 0);
INSERT INTO Colours(ColourName, IsDeleted) VALUES ('Yellow', 0);
INSERT INTO Colours(ColourName, IsDeleted) VALUES ('Blond', 0);
INSERT INTO Colours(ColourName, IsDeleted) VALUES ('Tan', 0);
INSERT INTO Colours(ColourName, IsDeleted) VALUES ('Fawn', 0);
INSERT INTO Colours(ColourName, IsDeleted) VALUES ('Tuxedo', 0);
INSERT INTO Colours(ColourName, IsDeleted) VALUES ('Blue Point', 0);
INSERT INTO Colours(ColourName, IsDeleted) VALUES ('Buff', 0);
INSERT INTO Colours(ColourName, IsDeleted) VALUES ('Cream', 0);
INSERT INTO Colours(ColourName, IsDeleted) VALUES ('Dilute Tortoiseshell', 0);
INSERT INTO Colours(ColourName, IsDeleted) VALUES ('Flame Point', 0);
INSERT INTO Colours(ColourName, IsDeleted) VALUES ('Lilac Point', 0);
INSERT INTO Colours(ColourName, IsDeleted) VALUES ('Seal Point', 0);
INSERT INTO Colours(ColourName, IsDeleted) VALUES ('Smoke', 0);
INSERT INTO Colours(ColourName, IsDeleted) VALUES ('Tabby', 0);
INSERT INTO Colours(ColourName, IsDeleted) VALUES ('Tortoiseshell', 0);
INSERT INTO Colours(ColourName, IsDeleted) VALUES ('Silver Marten', 0);
INSERT INTO Colours(ColourName, IsDeleted) VALUES ('Agouti', 0);
INSERT INTO Colours(ColourName, IsDeleted) VALUES ('Albino', 0);
INSERT INTO Colours(ColourName, IsDeleted) VALUES ('Calico', 0);
INSERT INTO Colours(ColourName, IsDeleted) VALUES ('Appaloosa', 0);
INSERT INTO Colours(ColourName, IsDeleted) VALUES ('Bay', 0);
INSERT INTO Colours(ColourName, IsDeleted) VALUES ('Buckskin', 0);
INSERT INTO Colours(ColourName, IsDeleted) VALUES ('Champagne', 0);
INSERT INTO Colours(ColourName, IsDeleted) VALUES ('Sorrel', 0);
INSERT INTO Colours(ColourName, IsDeleted) VALUES ('Cremello', 0);
INSERT INTO Colours(ColourName, IsDeleted) VALUES ('Dun', 0);
INSERT INTO Colours(ColourName, IsDeleted) VALUES ('Dapple Gray', 0);
INSERT INTO Colours(ColourName, IsDeleted) VALUES ('Grullo', 0);
INSERT INTO Colours(ColourName, IsDeleted) VALUES ('Liver', 0);
INSERT INTO Colours(ColourName, IsDeleted) VALUES ('Paint', 0);
INSERT INTO Colours(ColourName, IsDeleted) VALUES ('Palomino', 0);
INSERT INTO Colours(ColourName, IsDeleted) VALUES ('Perlino', 0);
INSERT INTO Colours(ColourName, IsDeleted) VALUES ('Piebald', 0);
INSERT INTO Colours(ColourName, IsDeleted) VALUES ('Pinto', 0);
INSERT INTO Colours(ColourName, IsDeleted) VALUES ('Olive', 0);
INSERT INTO Colours(ColourName, IsDeleted) VALUES ('Violet', 0);
INSERT INTO Colours(ColourName, IsDeleted) VALUES ('Rust', 0);
INSERT INTO Colours(ColourName, IsDeleted) VALUES ('Rufous', 0);
INSERT INTO Colours(ColourName, IsDeleted) VALUES ('Iridescent', 0);
INSERT INTO Colours(ColourName, IsDeleted) VALUES ('Pink', 0);
INSERT INTO Colours(ColourName, IsDeleted) VALUES ('Purple', 0);
INSERT INTO Colours(ColourName, IsDeleted) VALUES ('Roan', 0);
INSERT INTO Colours(ColourName, IsDeleted) VALUES ('Spotteda', 0);

/* insert breed */

-- Chó
insert INTO Breeds(BreedName,[Description],ThumbPath,IsDeleted) VALUES (N'Affenpinscher',N'Affenpinscher có vẻ ngoài gần giống với một con khỉ, với khuôn mặt ngắn và bộ lông nổi bật. Chúng thường được biết đến với tính cách tự tin, năng động và yêu thích sự chú ý từ chủ nhân.','/',0);
insert INTO Breeds(BreedName,[Description],ThumbPath,IsDeleted) VALUES (N'Akita',N'Akita là một giống chó lớn, mạnh mẽ và có tính cách rất độc lập. Chúng thường rất trung thành và bảo vệ gia đình, nhưng cũng có thể khá cứng đầu và đòi hỏi người chủ có kinh nghiệm.','/',0);
insert INTO Breeds(BreedName,[Description],ThumbPath,IsDeleted) VALUES (N'Akbash',N'Akbash là một giống chó chăn cừu với bộ lông màu trắng tinh khôi. Chúng thường được sử dụng làm chó bảo vệ hoặc chó chăn cừu do tính cách trung thành và sự độc lập.','/',0); 
insert INTO Breeds(BreedName,[Description],ThumbPath,IsDeleted) VALUES (N'Aussiedoodle',N'Aussiedoodle là kết hợp giữa Australian Shepherd và Poodle. Chúng có bộ lông mượt mà và thông minh từ hai giống cha mẹ. Aussiedoodle thường là những người bạn trung thành, thông minh và hoạt bát.','/',0);
insert INTO Breeds(BreedName,[Description],ThumbPath,IsDeleted) VALUES (N'Basenji',N'Basenji được biết đến với tiếng sủa độc đáo, mà có thể được mô tả như tiếng baroo. Họ là những chó săn nhỏ với bộ lông mịn và tính cách năng động. Basenji cũng thường rất sạch sẽ và có thể tự dọn dẹp bản thân giống như mèo.','/',0);

-- Mèo
insert INTO Breeds(BreedName,[Description],ThumbPath,IsDeleted) VALUES (N'Abyssinian',N'Abyssinian có bộ lông ngắn và dày, với màu sắc đa dạng và mắt lớn, sáng bóng. Chúng thường có tính cách hiếu động, sáng tạo và thích khám phá.','/',0);
insert INTO Breeds(BreedName,[Description],ThumbPath,IsDeleted) VALUES (N'Burmese',N'Mèo Burmese có bộ lông ngắn mịn và mắt to, nổi bật. Chúng thường rất âu yếm, trìu mến và thích gắn bó với con người.','/',0);
insert INTO Breeds(BreedName,[Description],ThumbPath,IsDeleted) VALUES (N'Calico',N'Calico là một mẫu lông, không phải là một giống cụ thể. Chúng được đặc trưng bởi ba màu chính: đỏ, trắng và đen. Mèo Calico có thể thuộc nhiều giống khác nhau, nhưng thường được biết đến với tính cách đa dạng và vui vẻ.','/',0); 
insert INTO Breeds(BreedName,[Description],ThumbPath,IsDeleted) VALUES (N'Chartreux',N'Chartreux là một giống mèo có bộ lông dày, màu xám xanh hoặc xám xanh dương. Chúng thường rất thân thiện, nhưng cũng có thể độc lập và thích giữ khoảng cách.','/',0);
insert INTO Breeds(BreedName,[Description],ThumbPath,IsDeleted) VALUES (N'Balinese',N'Balinese là phiên bản dài tóc của mèo Siamese. Chúng có bộ lông dài, mềm mại và màu sắc đa dạng. Balinese thường thông minh, yêu thương và thích thể hiện sự chú ý.','/',0);

-- Thỏa
insert INTO Breeds(BreedName,[Description],ThumbPath,IsDeleted) VALUES (N'Angora Rabbit',N'Angora Rabbit nổi tiếng với bộ lông dài, mịn và mềm mại. Chúng thường cần chăm sóc đặc biệt để giữ cho bộ lông không bị rối và giữ ấm. Angora thường rất hiền lành và thích được chăm sóc.','/',0);
insert INTO Breeds(BreedName,[Description],ThumbPath,IsDeleted) VALUES (N'Beveren',N'Beveren là một giống thỏ có kích thước lớn và có bộ lông ngắn mịn. Chúng có thể có màu sắc khác nhau như xanh, đen, đỏ và trắng. Beveren thường có tính cách bình tĩnh và thân thiện.','/',0);
insert INTO Breeds(BreedName,[Description],ThumbPath,IsDeleted) VALUES (N'Belgian Hare',N'Belgian Hare là một giống thỏ có hình dáng svelte và bộ lông ngắn mượt. Chúng thường rất nhanh nhẹn, năng động và thích vận động.','/',0); 
insert INTO Breeds(BreedName,[Description],ThumbPath,IsDeleted) VALUES (N'Britannia Petite',N'Britannia Petite là một giống thỏ nhỏ, nhưng năng động và nhanh nhẹn. Chúng có bộ lông ngắn và màu sắc đa dạng. Britannia Petite thường rất nhanh nhẹn và tò mò.','/',0);
insert INTO Breeds(BreedName,[Description],ThumbPath,IsDeleted) VALUES (N'Checkered Giant',N'Checkered Giant là một giống thỏ lớn, có bộ lông ngắn mượt và màu sắc phân biệt rõ ràng. Chúng có thể có màu đen và trắng hoặc xám và trắng. Checkered Giant thường là những người bạn trung thành và hiền lành.','/',0);

-- Ngựa
insert INTO Breeds(BreedName,[Description],ThumbPath,IsDeleted) VALUES (N'Appaloosa',N'Appaloosa nổi tiếng với bộ lông có các đốm hay vệt màu trên nền lông màu sắc khác nhau. Chúng có vẻ ngoài đặc biệt và đa dạng về màu sắc. Appaloosa thường thông minh, linh hoạt và có khả năng làm việc tốt.','/',0);
insert INTO Breeds(BreedName,[Description],ThumbPath,IsDeleted) VALUES (N'Arabian',N'Arabian là một trong những giống ngựa cổ điển nhất và được biết đến với vẻ ngoài tinh tế, dáng vẻ điển hình và sức bền vững. Chúng thường có đầu nhỏ, vòi sen và thân hình mảnh mai. Arabian là những người bạn trung thành, thông minh và nhanh nhẹn.','/',0);
insert INTO Breeds(BreedName,[Description],ThumbPath,IsDeleted) VALUES (N'Belgian',N'Belgian là một giống ngựa nặng, mạnh mẽ và có bộ lông dày. Chúng thường được sử dụng cho công việc kéo, vận chuyển và canh tác. Belgian thường có tính cách trầm tĩnh, bền bỉ và trung thành.','/',0); 
insert INTO Breeds(BreedName,[Description],ThumbPath,IsDeleted) VALUES (N'Clydesdale',N'Clydesdale là một giống ngựa lớn có bộ lông dày mạnh mẽ và thường có một vòng mảnh mai quanh cổ gọi là bèo. Chúng thường được sử dụng cho công việc kéo và hiện đã trở thành biểu tượng cho các cuộc diễu hành và sự kiện. Clydesdale thường thông minh, nhanh nhẹn và dễ đào tạo.','/',0);
insert INTO Breeds(BreedName,[Description],ThumbPath,IsDeleted) VALUES (N'Connemara',N'Connemara là một giống ngựa nhỏ có thân hình mạnh mẽ, chắc chắn và bộ lông dày. Chúng thường được biết đến với tính cách mạnh mẽ, can đảm và đa năng. Connemara thích hợp cho nhiều môn thể thao như cưỡi và nhảy vượt.','/',0);

-- Chim
insert INTO Breeds(BreedName,[Description],ThumbPath,IsDeleted) VALUES (N'African Gre',N'African Grey Parrot là một loài vẹt thông minh và nổi tiếng với khả năng học nói và giao tiếp. Chúng có bộ lông xám đậm và khuôn mặt tích cực. African Grey thường rất tình cảm với chủ nhân và có khả năng học hỏi rất tốt.','/',0);
insert INTO Breeds(BreedName,[Description],ThumbPath,IsDeleted) VALUES (N'Brotogeris',N'Brotogeris là một nhóm chim thuộc họ Psittacidae, gồm nhiều loài nhỏ. Chúng thường có bộ lông màu sắc rực rỡ và đuôi dài. Brotogeris thích sự xã giao và thường rất hoạt bát.','/',0);
insert INTO Breeds(BreedName,[Description],ThumbPath,IsDeleted) VALUES (N'Button-Quail',N'Button-Quail, hay còn được gọi là Chim cút nút, là loài chim nhỏ có thói quen sống trên mặt đất. Chúng có bộ lông màu sắc tương phản và thường có thói quen ẩn mình khi cảm thấy nguy hiểm. Button-Quail thường là các loài chim rất nhỏ và rất dễ thương.
','/',0); 
insert INTO Breeds(BreedName,[Description],ThumbPath,IsDeleted) VALUES (N'Caique',N'Caique là một loài vẹt rất năng động và vui vẻ, nổi tiếng với bộ lông sặc sỡ và tính cách hoạt bát. Chúng thường rất thân thiện và thích tham gia vào các hoạt động vận động.','/',0);
insert INTO Breeds(BreedName,[Description],ThumbPath,IsDeleted) VALUES (N'Canary',N'Canary là một loài chim thuộc họ Fringillidae, nổi tiếng với hát líu lo. Chúng thường có bộ lông màu sắc đa dạng, từ màu vàng đến màu đỏ, đen và trắng. Canary là các loài chim cảnh phổ biến và thường được nuôi để trang trí và nghe hát.','/',0);


/* insert location */

-- ha noi
insert into Locations(Street, Wards, DistrictCity, ProvinceCity, IsDeleted) VALUES('123', N'Thị trấn Trâu Quỳ',N'Huyện Gia Lâm',N'Hà Nội', 0);
insert into Locations(Street, Wards, DistrictCity, ProvinceCity, IsDeleted) VALUES('326', N'Xã Cam Thượng',N'Huyện Ba Vì',N'Hà Nội', 0);
insert into Locations(Street, Wards, DistrictCity, ProvinceCity, IsDeleted) VALUES('045', N'Thị trấn Chi Đông',N'Huyện Mê Linh',N'Hà Nội', 0);
insert into Locations(Street, Wards, DistrictCity, ProvinceCity, IsDeleted) VALUES('563', N'Xã Bình Phú',N'Huyện Thạch Thất',N'Hà Nội', 0);
insert into Locations(Street, Wards, DistrictCity, ProvinceCity, IsDeleted) VALUES('552', N'Thị trấn Quốc Oai',N'Huyện Quốc Oai',N'Hà Nội', 0);

-- ho chi minh
insert into Locations(Street, Wards, DistrictCity, ProvinceCity, IsDeleted) VALUES('552', N'Thị trấn Tân Túc',N'Huyện Bình Chánh',N'Hồ Chí Minh', 0);
insert into Locations(Street, Wards, DistrictCity, ProvinceCity, IsDeleted) VALUES('236', N'Phường Cô Giang',N'Quận 1',N'Hồ Chí Minh', 0);
insert into Locations(Street, Wards, DistrictCity, ProvinceCity, IsDeleted) VALUES('556482', N'Phường 05',N'Quận 5',N'Hồ Chí Minh', 0);
insert into Locations(Street, Wards, DistrictCity, ProvinceCity, IsDeleted) VALUES('242', N'Phường 10',N'Quận Gò Vấp',N'Hồ Chí Minh', 0);
insert into Locations(Street, Wards, DistrictCity, ProvinceCity, IsDeleted) VALUES('113', N'Phường 06',N'Quận Bình Thạnh',N'Hồ Chí Minh', 0);

-- binh dinh
insert into Locations(Street, Wards, DistrictCity, ProvinceCity, IsDeleted) VALUES('764', N'Thị trấn Tam Quan',N'Huyện Hoài Nhơn543',N'Bình Định', 0);
insert into Locations(Street, Wards, DistrictCity, ProvinceCity, IsDeleted) VALUES('886', N'Xã Hoài Châu Bắc',N'Huyện Phù Cát548',N'Bình Định', 0);
insert into Locations(Street, Wards, DistrictCity, ProvinceCity, IsDeleted) VALUES('043', N'Xã Hoài Hảo',N'Huyện Phù Mỹ545',N'Bình Định', 0);
insert into Locations(Street, Wards, DistrictCity, ProvinceCity, IsDeleted) VALUES('554', N'Xã Hoài Phú',N'Huyện Vân Canh551',N'Bình Định', 0);
insert into Locations(Street, Wards, DistrictCity, ProvinceCity, IsDeleted) VALUES('011', N'Xã Tam Quan Nam',N'Thành phố Qui Nhơn540',N'Bình Định', 0);

-- phu yen
insert into Locations(Street, Wards, DistrictCity, ProvinceCity, IsDeleted) VALUES('723', N'Thị trấn Hoà Hiệp Trung',N'Huyện Đông Hòa',N'Phú Yên', 0);
insert into Locations(Street, Wards, DistrictCity, ProvinceCity, IsDeleted) VALUES('723', N'Xã Đa Lộc',N'Huyện Đồng Xuân',N'Phú Yên', 0);
insert into Locations(Street, Wards, DistrictCity, ProvinceCity, IsDeleted) VALUES('723', N'Thị trấn Củng Sơn',N'Huyện Sơn Hòa',N'Phú Yên', 0);
insert into Locations(Street, Wards, DistrictCity, ProvinceCity, IsDeleted) VALUES('723', N'Xã An Chấn',N'Huyện Tuy An',N'Phú Yên', 0);
insert into Locations(Street, Wards, DistrictCity, ProvinceCity, IsDeleted) VALUES('723', N'Phường Xuân Đài',N'Thị xã Sông Cầu',N'Phú Yên', 0);

/* roles */
INSERT into Roles(Id, [Name], NormalizedName, ConcurrencyStamp) VALUES ('13b9d4ca-62c4-4507-9b15-a2ad0955f586', 'Admin','ADMIN',1);
INSERT into Roles(Id, [Name], NormalizedName, ConcurrencyStamp) VALUES ('49f8f876-6577-44e7-8e8c-de704b93cd96', 'User','USER',2);

/* users */
insert into Users (Id, FirstName, LastName, IsDeleted, UserName, Email, NormalizedUserName, NormalizedEmail, EmailCOnfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount) values ('7abf45ff-e629-4205-a147-4f68605cea33', 'Bobette', 'Almon', 1, 'balmon0@npr.org', 'balmon0@sina.com.cn', 'BALMON0@SINA.COM.CN', 'BALMON0@SINA.COM.CN', 1, '$2a$04$hxLLTsXtwFcMTgDTksDZG..ycpwI/08ZntXdoRmQ/HOkSqvJOoSS2', '$2a$04$zwckCylv5veANvtFzswwT.1oiHMYaWw4FNBFzT70sq3xTlhGizXFO', '$2a$04$395ShxuOWSn1b8lRLBYMku.LO.h7NNe4i6xdrZA01GP5PARWxrtIC', '836 760 4450', 1, 0, '2023-09-24', 0, 0);
insert into Users (Id, FirstName, LastName, IsDeleted, UserName, Email, NormalizedUserName, NormalizedEmail, EmailCOnfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount) values ('b553ce16-7c6c-462f-a9da-970041488ade', 'Rania', 'Giottini', 0, 'rgiottini1@shop-pro.jp', 'rgiottini1@elpais.com', 'RGIOTTINI1@ELPAIS.COM', 'RGIOTTINI1@ELPAIS.COM', 1, '$2a$04$XuE8eykLoY4hshzy7hoBb.mIf2vGNh0T7Yphmy99rs4OZY9THhm0a', '$2a$04$JAZjGuLqtUY6ejMbDQXHjusT1r9FQf5zMUxg4jUWL4g8QMm9m/FMe', '$2a$04$5OQarJCsFI/bu3i71dbMs.5RLx0cLv7rB3Q9gwkgIcs65yg0XKEBO', '101 255 7722', 0, 1, '2024-02-18', 1, 0);
insert into Users (Id, FirstName, LastName, IsDeleted, UserName, Email, NormalizedUserName, NormalizedEmail, EmailCOnfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount) values ('b5566616-7c6c-462f-a9da-970041488ade', 'Rania', 'Giottini', 0, 'rgiottini1@shop-pro.jp', 'rgiottini1@elpais.com', 'RGIOTTINI2@ELPAIS.COM', 'RGIOTTINI2@ELPAIS.COM', 1, '$2a$04$XuE8eykLoY4hshzy7hoBb.mIf2vGNh0T7Yphmy99rs4OZY9THhm0a', '$2a$04$JAZjGuLqtUY6ejMbDQXHjusT1r9FQf5zMUxg4jUWL4g8QMm9m/FMe', '$2a$04$5OQarJCsFI/bu3i71dbMs.5RLx0cLv7rB3Q9gwkgIcs65yg0XKEBO', '101 255 7722', 0, 1, '2024-02-18', 1, 0);
insert into Users (Id, FirstName, LastName, IsDeleted, UserName, Email, NormalizedUserName, NormalizedEmail, EmailCOnfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount) values ('b553ce16-7c6c-462f-a9da-97fgh1488ade', 'Rania', 'Giottini', 0, 'rgiottini1@shop-pro.jp', 'rgiottini1@elpais.com', 'RGIOTTINI3@ELPAIS.COM', 'RGIOTTINI3@ELPAIS.COM', 1, '$2a$04$XuE8eykLoY4hshzy7hoBb.mIf2vGNh0T7Yphmy99rs4OZY9THhm0a', '$2a$04$JAZjGuLqtUY6ejMbDQXHjusT1r9FQf5zMUxg4jUWL4g8QMm9m/FMe', '$2a$04$5OQarJCsFI/bu3i71dbMs.5RLx0cLv7rB3Q9gwkgIcs65yg0XKEBO', '101 255 7722', 0, 1, '2024-02-18', 1, 0);


/* userRoles */
insert into UserRoles(UserId, RoleId) VALUES('7abf45ff-e629-4205-a147-4f68605cea33','13b9d4ca-62c4-4507-9b15-a2ad0955f586');
insert into UserRoles(UserId, RoleId) VALUES('b553ce16-7c6c-462f-a9da-970041488ade','49f8f876-6577-44e7-8e8c-de704b93cd96');
insert into UserRoles(UserId, RoleId) VALUES('b5566616-7c6c-462f-a9da-970041488ade','49f8f876-6577-44e7-8e8c-de704b93cd96');
insert into UserRoles(UserId, RoleId) VALUES('b553ce16-7c6c-462f-a9da-97fgh1488ade','49f8f876-6577-44e7-8e8c-de704b93cd96');


/* volunteer */
insert into Volunteers(DateStart, IsDeleted, LocationId, UserId) VALUEs ('2024-11-22', 0, 5,'b553ce16-7c6c-462f-a9da-970041488ade');
insert into Volunteers(DateStart, IsDeleted, LocationId, UserId) VALUEs ('2024-11-22', 0, 14,'b5566616-7c6c-462f-a9da-970041488ade');
insert into Volunteers(DateStart, IsDeleted, LocationId, UserId) VALUEs ('2024-11-22', 0, 11,'b553ce16-7c6c-462f-a9da-97fgh1488ade');

/* owner */
insert into O() VALUEs([Name], UserId, LocationId) VALUEs()

/* donor */




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
DBCC CHECKIDENT ('dbo.UserClaims', RESEED, 0)
go
DBCC CHECKIDENT ('dbo.VolunteerAudits', RESEED, 0)
go
DBCC CHECKIDENT ('dbo.VolunteerRoles', RESEED, 0)
go
DBCC CHECKIDENT ('dbo.Volunteers', RESEED, 0)
go


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

-- Thỏ
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
insert INTO Breeds(BreedName,[Description],ThumbPath,IsDeleted) VALUES (N'Button-Quail',N'Button-Quail, hay còn được gọi là Chim cút nút, là loài chim nhỏ có thói quen sống trên mặt đất. Chúng có bộ lông màu sắc tương phản và thường có thói quen ẩn mình khi cảm thấy nguy hiểm. Button-Quail thường là các loài chim rất nhỏ và rất dễ thương.','/',0); 
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
insert into Users (Id, FirstName, LastName, IsDeleted, UserName, Email, NormalizedUserName, NormalizedEmail, EmailCOnfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount) values ('7abf45ff-e629-4205-a147-4f68605cea33', 'Bobette', 'Almon', 1, 'balmon0@npr.org', 'balmon0@sina.com.cn', 'BALMON0@SINA.COM.CN', 'BALMON0@SINA.COM.CN', 1, '$2a$04$hxLLTsXtwFcMTgDTksDZG..ycpwI/08ZntXdoRmQ/HOkSqvJOoSS2', '$2a$04$zwckCylv5veANvtFzswwT.1oiHMYaWw4FNBFzT70sq3xTlhGizXFO', '$2a$04$395ShxuOWSn1b8lRLBYMku.LO.h7NNe4i6xdrZA01GP5PARWxrtIC', '836 760 4450', 1, 0, null, 0, 0);
insert into Users (Id, FirstName, LastName, IsDeleted, UserName, Email, NormalizedUserName, NormalizedEmail, EmailCOnfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount) values ('b553ce16-7c6c-462f-a9da-970041488ade', 'Rania', 'Giottini', 0, 'rgiottini1@elpais.com', 'rgiottini1@elpais.com', 'RGIOTTINI1@ELPAIS.COM', 'RGIOTTINI1@ELPAIS.COM', 1, '$2a$04$XuE8eykLoY4hshzy7hoBb.mIf2vGNh0T7Yphmy99rs4OZY9THhm0a', '$2a$04$JAZjGuLqtUY6ejMbDQXHjusT1r9FQf5zMUxg4jUWL4g8QMm9m/FMe', '$2a$04$5OQarJCsFI/bu3i71dbMs.5RLx0cLv7rB3Q9gwkgIcs65yg0XKEBO', '101 255 7722', 0, 1, null, 1, 0);
insert into Users (Id, FirstName, LastName, IsDeleted, UserName, Email, NormalizedUserName, NormalizedEmail, EmailCOnfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount) values ('b5566616-7c6c-462f-a9da-970041488ade', 'Rania', 'Giottini', 0, 'rgiottini2@elpais.com', 'rgiottini2@elpais.com', 'RGIOTTINI2@ELPAIS.COM', 'RGIOTTINI2@ELPAIS.COM', 1, '$2a$04$XuE8eykLoY4hshzy7hoBb.mIf2vGNh0T7Yphmy99rs4OZY9THhm0a', '$2a$04$JAZjGuLqtUY6ejMbDQXHjusT1r9FQf5zMUxg4jUWL4g8QMm9m/FMe', '$2a$04$5OQarJCsFI/bu3i71dbMs.5RLx0cLv7rB3Q9gwkgIcs65yg0XKEBO', '101 255 7722', 0, 1, null, 1, 0);
insert into Users (Id, FirstName, LastName, IsDeleted, UserName, Email, NormalizedUserName, NormalizedEmail, EmailCOnfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount) values ('b553ce16-7c6c-462f-a9da-97fgh1488ade', 'Rania', 'Giottini', 0, 'rgiottini3@elpais.com', 'rgiottini3@elpais.com', 'RGIOTTINI3@ELPAIS.COM', 'RGIOTTINI3@ELPAIS.COM', 1, '$2a$04$XuE8eykLoY4hshzy7hoBb.mIf2vGNh0T7Yphmy99rs4OZY9THhm0a', '$2a$04$JAZjGuLqtUY6ejMbDQXHjusT1r9FQf5zMUxg4jUWL4g8QMm9m/FMe', '$2a$04$5OQarJCsFI/bu3i71dbMs.5RLx0cLv7rB3Q9gwkgIcs65yg0XKEBO', '101 255 7722', 0, 1, null, 1, 0);


/* userRoles */
insert into UserRoles(UserId, RoleId) VALUES('7abf45ff-e629-4205-a147-4f68605cea33','13b9d4ca-62c4-4507-9b15-a2ad0955f586');
insert into UserRoles(UserId, RoleId) VALUES('b553ce16-7c6c-462f-a9da-970041488ade','49f8f876-6577-44e7-8e8c-de704b93cd96');
insert into UserRoles(UserId, RoleId) VALUES('b5566616-7c6c-462f-a9da-970041488ade','49f8f876-6577-44e7-8e8c-de704b93cd96');
insert into UserRoles(UserId, RoleId) VALUES('b553ce16-7c6c-462f-a9da-97fgh1488ade','49f8f876-6577-44e7-8e8c-de704b93cd96');


/* volunteer */
insert into Volunteers(DateStart, IsDeleted, LocationId, UserId) VALUEs ('2024-11-22', 0, 5,'b553ce16-7c6c-462f-a9da-970041488ade');
insert into Volunteers(DateStart, IsDeleted, LocationId, UserId) VALUEs ('2024-11-22', 0, 14,'b5566616-7c6c-462f-a9da-970041488ade');
insert into Volunteers(DateStart, IsDeleted, LocationId, UserId) VALUEs ('2024-11-22', 0, 11,'b553ce16-7c6c-462f-a9da-97fgh1488ade');

/* donor */
insert into Donors([Name], TotalDonation, LocationId, IsDeleted) Values('Nguyễn Văn A', 100.00, 1, 0)
go
insert into Donors([Name], TotalDonation, LocationId, IsDeleted) Values('Nguyễn Văn B', 200.00, 1, 0)
go
insert into Donors([Name], TotalDonation, LocationId, IsDeleted) Values('Nguyễn Văn C', 300.00, 8, 0)
go
insert into Donors([Name], TotalDonation, LocationId, IsDeleted) Values('Nguyễn Văn D', 400.00, 11, 0)
go
insert into Donors([Name], TotalDonation, LocationId, IsDeleted) Values('Nguyễn Văn E', 500.00, 19, 0)
go


/* owner */
insert into Owners(IsDeleted,UserId,LocationId) VALUES(0, '7abf45ff-e629-4205-a147-4f68605cea33', '')
go
insert into Owners(IsDeleted,UserId,LocationId) VALUES(0, 'b553ce16-7c6c-462f-a9da-970041488ade', '')
go
insert into Owners(IsDeleted,UserId,LocationId) VALUES(0, 'b5566616-7c6c-462f-a9da-970041488ade', '')
go
insert into Owners(IsDeleted,UserId,LocationId) VALUES(0, 'b553ce16-7c6c-462f-a9da-97fgh1488ade', '')
go

/* insert pet */
INSERT INTO Pets (PetName, PetDescription, PetWeight, PetAge, PetGender, PetDesexed, PetWormed, PetVaccined, PetMicrochipped, PetEntryDate, [Status], IsDeleted, VolunteerId, LocationId, OwnerId)
VALUES('Mittens', 'Fluffy white cat', 5.2, 2, 1, 1, 1, 1, 1, DATEADD(DAY, RAND(), GETDATE()), 1, 0, 1, 1, 1)
go

INSERT INTO Pets (PetName, PetDescription, PetWeight, PetAge, PetGender, PetDesexed, PetWormed, PetVaccined, PetMicrochipped, PetEntryDate, [Status], IsDeleted, VolunteerId, LocationId, OwnerId)
VALUES('Sparky', 'Playful brown dog', 12.5, 1, 0, 1, 0, 1, 0, DATEADD(DAY, RAND(), GETDATE()), 1, 0, 2, 5, 2)
go

INSERT INTO Pets (PetName, PetDescription, PetWeight, PetAge, PetGender, PetDesexed, PetWormed, PetVaccined, PetMicrochipped, PetEntryDate, [Status], IsDeleted, VolunteerId, LocationId, OwnerId)
VALUES ('Bailey', 'Mischievous Beagle mix', 17.8, 1, 0, 1, 0, 1, 0, DATEADD(DAY, RAND(), GETDATE()), 0, 0, 2, 12, 4)
go

INSERT INTO Pets (PetName, PetDescription, PetWeight, PetAge, PetGender, PetDesexed, PetWormed, PetVaccined, PetMicrochipped, PetEntryDate, [Status], IsDeleted, VolunteerId, LocationId, OwnerId)
VALUES('Pepper', 'Tiny Chihuahua', 3.2, 4, 1, 1, 1, 1, 1, DATEADD(DAY, RAND(), GETDATE()), 1, 0, 1, 5, 1)
go

INSERT INTO Pets (PetName, PetDescription, PetWeight, PetAge, PetGender, PetDesexed, PetWormed, PetVaccined, PetMicrochipped, PetEntryDate, [Status], IsDeleted, VolunteerId, LocationId, OwnerId)
VALUES('Luna', 'Playful Golden Retriever', 28.1, 2, 1, 0, 1, 1, 0, DATEADD(DAY, RAND(), GETDATE()), 1, 0, 2, 7, 2)
go

INSERT INTO Pets (PetName, PetDescription, PetWeight, PetAge, PetGender, PetDesexed, PetWormed, PetVaccined, PetMicrochipped, PetEntryDate, [Status], IsDeleted, VolunteerId, LocationId, OwnerId)
VALUES('Buddy', 'Mischievous Dalmatian', 22.5, 3, 0, 1, 0, 1, 1, DATEADD(DAY, RAND(), GETDATE()), 1, 0, 1, 9, 4)
go

INSERT INTO Pets (PetName, PetDescription, PetWeight, PetAge, PetGender, PetDesexed, PetWormed, PetVaccined, PetMicrochipped, PetEntryDate, [Status], IsDeleted, VolunteerId, LocationId, OwnerId)
VALUES('Bella', 'Gentle giant Great Dane', 42.7, 4, 1, 0, 1, 1, 1, DATEADD(DAY, RAND(), GETDATE()), 1, 0, 2, 14, 1)
go

INSERT INTO Pets (PetName, PetDescription, PetWeight, PetAge, PetGender, PetDesexed, PetWormed, PetVaccined, PetMicrochipped, PetEntryDate, [Status], IsDeleted, VolunteerId, LocationId, OwnerId)
VALUES('Bella', 'Fluffy white Persian cat', 5.8, 4, 1, 1, 1, 1, 0, DATEADD(DAY, RAND(), GETDATE()), 1, 0, 2, 14, 1)
go

INSERT INTO Pets (PetName, PetDescription, PetWeight, PetAge, PetGender, PetDesexed, PetWormed, PetVaccined, PetMicrochipped, PetEntryDate, [Status], IsDeleted, VolunteerId, LocationId, OwnerId)
VALUES('Max', 'Lazy orange tabby cat', 12.9, 5, 0, 1, 0, 1, 1, DATEADD(DAY, RAND(), GETDATE()), 0, 0, 3, 15, 3)
go

INSERT INTO Pets (PetName, PetDescription, PetWeight, PetAge, PetGender, PetDesexed, PetWormed, PetVaccined, PetMicrochipped, PetEntryDate, [Status], IsDeleted, VolunteerId, LocationId, OwnerId)
VALUES('Buddy', 'Mischievous Dalmatian', 22.5, 3, 0, 1, 0, 1, 1, DATEADD(DAY, RAND(), GETDATE()), 1, 0, 1, 9, 4)
go

INSERT INTO Pets (PetName, PetDescription, PetWeight, PetAge, PetGender, PetDesexed, PetWormed, PetVaccined, PetMicrochipped, PetEntryDate, [Status], IsDeleted, VolunteerId, LocationId, OwnerId)
VALUES('Luna', 'Playful Golden Retriever', 28.1, 2, 1, 0, 1, 1, 0, DATEADD(DAY, RAND(), GETDATE()), 1, 0, 2, 7, 2)
go

INSERT INTO Pets (PetName, PetDescription, PetWeight, PetAge, PetGender, PetDesexed, PetWormed, PetVaccined, PetMicrochipped, PetEntryDate, [Status], IsDeleted, VolunteerId, LocationId, OwnerId)
VALUES('Bailey', 'Mischievous Beagle mix', 17.8, 1, 0, 1, 0, 1, 0, DATEADD(DAY, RAND(), GETDATE()), 0, 0, 2, 12, 4)
go

INSERT INTO Pets (PetName, PetDescription, PetWeight, PetAge, PetGender, PetDesexed, PetWormed, PetVaccined, PetMicrochipped, PetEntryDate, [Status], IsDeleted, VolunteerId, LocationId, OwnerId)
VALUES('Charlie', 'Friendly black Labrador', 25.4, 3, 0, 1, 1, 0, 1, DATEADD(DAY, RAND(), GETDATE()), 1, 0, 3, 10, 3)
go

INSERT INTO Pets (PetName, PetDescription, PetWeight, PetAge, PetGender, PetDesexed, PetWormed, PetVaccined, PetMicrochipped, PetEntryDate, [Status], IsDeleted, VolunteerId, LocationId, OwnerId)
VALUES('Max', 'Lazy orange tabby cat', 12.9, 5, 0, 1, 0, 1, 1, DATEADD(DAY, RAND(), GETDATE()), 0, 0, 3, 15, 3)
go

INSERT INTO Pets (PetName, PetDescription, PetWeight, PetAge, PetGender, PetDesexed, PetWormed, PetVaccined, PetMicrochipped, PetEntryDate, [Status], IsDeleted, VolunteerId, LocationId, OwnerId)
VALUES('Bella', 'Fluffy white Persian cat', 5.8, 4, 1, 1, 1, 1, 0, DATEADD(DAY, RAND(), GETDATE()), 1, 0, 2, 14, 1)
go

INSERT INTO Pets (PetName, PetDescription, PetWeight, PetAge, PetGender, PetDesexed, PetWormed, PetVaccined, PetMicrochipped, PetEntryDate, [Status], IsDeleted, VolunteerId, LocationId, OwnerId)
VALUES('Buddy', 'Mischievous Dalmatian', 22.5, 3, 0, 1, 0, 1, 1, DATEADD(DAY, RAND(), GETDATE()), 1, 0, 1, 9, 4)
go

INSERT INTO Pets (PetName, PetDescription, PetWeight, PetAge, PetGender, PetDesexed, PetWormed, PetVaccined, PetMicrochipped, PetEntryDate, [Status], IsDeleted, VolunteerId, LocationId, OwnerId)
VALUES('Luna', 'Playful Golden Retriever', 28.1, 2, 1, 0, 1, 1, 0, DATEADD(DAY, RAND(), GETDATE()), 0, 0, 2, 12, 4)
go

INSERT INTO Pets (PetName, PetDescription, PetWeight, PetAge, PetGender, PetDesexed, PetWormed, PetVaccined, PetMicrochipped, PetEntryDate, [Status], IsDeleted, VolunteerId, LocationId, OwnerId)
VALUES('Bailey', 'Mischievous Beagle mix', 17.8, 1, 0, 1, 0, 1, 0, DATEADD(DAY, RAND(), GETDATE()), 0, 0, 2, 12, 4)
go

INSERT INTO Pets (PetName, PetDescription, PetWeight, PetAge, PetGender, PetDesexed, PetWormed, PetVaccined, PetMicrochipped, PetEntryDate, [Status], IsDeleted, VolunteerId, LocationId, OwnerId)
VALUES('Charlie', 'Friendly black Labrador', 25.4, 3, 0, 1, 1, 0, 1, DATEADD(DAY, RAND(), GETDATE()), 1, 0, 3, 10, 3)
go

INSERT INTO Pets (PetName, PetDescription, PetWeight, PetAge, PetGender, PetDesexed, PetWormed, PetVaccined, PetMicrochipped, PetEntryDate, [Status], IsDeleted, VolunteerId, LocationId, OwnerId)
VALUES('Max', 'Lazy orange tabby cat', 12.9, 5, 0, 1, 0, 1, 1, DATEADD(DAY, RAND(), GETDATE()), 0, 0, 3, 15, 3)
go

/* pet image */
insert into PetImages(ImgPath,PetId,IsDeleted) Values('/', 1, 0)
go
insert into PetImages(ImgPath,PetId,IsDeleted) Values('/', 2, 0)
go
insert into PetImages(ImgPath,PetId,IsDeleted) Values('/', 3, 0)
go
insert into PetImages(ImgPath,PetId,IsDeleted) Values('/', 4, 0)
go
insert into PetImages(ImgPath,PetId,IsDeleted) Values('/', 5, 0)
go
insert into PetImages(ImgPath,PetId,IsDeleted) Values('/', 6, 0)
go
insert into PetImages(ImgPath,PetId,IsDeleted) Values('/', 7, 0)
go
insert into PetImages(ImgPath,PetId,IsDeleted) Values('/', 8, 0)
go
insert into PetImages(ImgPath,PetId,IsDeleted) Values('/', 9, 0)
go
insert into PetImages(ImgPath,PetId,IsDeleted) Values('/', 10, 0)
go
insert into PetImages(ImgPath,PetId,IsDeleted) Values('/', 11, 0)
go
insert into PetImages(ImgPath,PetId,IsDeleted) Values('/', 12, 0)
go
insert into PetImages(ImgPath,PetId,IsDeleted) Values('/', 13, 0)
go
insert into PetImages(ImgPath,PetId,IsDeleted) Values('/', 14, 0)
go
insert into PetImages(ImgPath,PetId,IsDeleted) Values('/', 15, 0)
go
insert into PetImages(ImgPath,PetId,IsDeleted) Values('/', 16, 0)
go
insert into PetImages(ImgPath,PetId,IsDeleted) Values('/', 17, 0)
go
insert into PetImages(ImgPath,PetId,IsDeleted) Values('/', 18, 0)
go
insert into PetImages(ImgPath,PetId,IsDeleted) Values('/', 19, 0)
go
insert into PetImages(ImgPath,PetId,IsDeleted) Values('/', 20, 0)
go


/* pet audit */
INSERT INTO PetAudits (PetId, VolunteerId, LocationId, OwnerId, PetName, PetDescription, PetWeight, PetAge, PetGender, PetDesexed, PetWormed, PetVaccined, PetMicrochipped, PetEntryDate, [Version], ChangeDate, IsDeleted,UserChangeId)
VALUES (1,1,1,1,'Bông','Chó Poodle màu nâu',5.0,3,1,1,1,1,1,GETDATE(),0,GETDATE(),0,'7abf45ff-e629-4205-a147-4f68605cea33')
go

INSERT INTO PetAudits (PetId, VolunteerId, LocationId, OwnerId, PetName, PetDescription, PetWeight, PetAge, PetGender, PetDesexed, PetWormed, PetVaccined, PetMicrochipped, PetEntryDate, [Version], ChangeDate, IsDeleted,UserChangeId)
VALUES (2,2,2,2,'Mèo Kitty','Mèo Anh lông dài màu xám',3.5,2,0,1,1,0,1,GETDATE(),0,GETDATE(),0,'b553ce16-7c6c-462f-a9da-970041488ade')
go

INSERT INTO PetAudits (PetId, VolunteerId, LocationId, OwnerId, PetName, PetDescription, PetWeight, PetAge, PetGender, PetDesexed, PetWormed, PetVaccined, PetMicrochipped, PetEntryDate, [Version], ChangeDate, IsDeleted,UserChangeId)
VALUES (3,3,3,1,'Tê tê','Vảy vút nâu',10.0,5,0,0,0,0,0,GETDATE(),0,GETDATE(),0,'b553ce16-7c6c-462f-a9da-970041488ade')
go

INSERT INTO PetAudits (PetId, VolunteerId, LocationId, OwnerId, PetName, PetDescription, PetWeight, PetAge, PetGender, PetDesexed, PetWormed, PetVaccined, PetMicrochipped, PetEntryDate, [Version], ChangeDate, IsDeleted,UserChangeId)
VALUES (4,1,10,1,'Chim cánh cụt','Chim cánh cụt Hoàng đế',15.0,10,0,0,0,0,0,GETDATE(),0,GETDATE(),0,'7abf45ff-e629-4205-a147-4f68605cea33')
go

INSERT INTO PetAudits (PetId,VolunteerId,LocationId,OwnerId,PetName,PetDescription,PetWeight,PetAge,PetGender,PetDesexed,PetWormed,PetVaccined,PetMicrochipped,PetEntryDate,[Version],ChangeDate,IsDeleted,UserChangeId)
VALUES (5,1,1,1,'Cá heo','Cá heo mũi chai',150.0,15,0,0,0,0,0,GETDATE(),0,GETDATE(),0,'b553ce16-7c6c-462f-a9da-970041488ade')
go

INSERT INTO PetAudits (PetId,VolunteerId,LocationId,OwnerId,PetName,PetDescription,PetWeight,PetAge,PetGender,PetDesexed,PetWormed,PetVaccined,PetMicrochipped,PetEntryDate,[Version],ChangeDate,IsDeleted,UserChangeId)
VALUES (6,2,2,2,'Hổ','Hổ Đông Dương',200.0,20,1,0,0,0,0,GETDATE(),0,GETDATE(),0,'b5566616-7c6c-462f-a9da-970041488ade')
go

INSERT INTO PetAudits (PetId,VolunteerId,LocationId,OwnerId,PetName,PetDescription,PetWeight,PetAge,PetGender,PetDesexed,PetWormed,PetVaccined,PetMicrochipped,PetEntryDate,[Version],ChangeDate,IsDeleted,UserChangeId)
VALUES (7,3,3,1,'Voi','Voi châu Á',300.0,30,1,1,0,0,0,GETDATE(),0,GETDATE(),0,'7abf45ff-e629-4205-a147-4f68605cea33')
go

INSERT INTO PetAudits (PetId,VolunteerId,LocationId,OwnerId,PetName,PetDescription,PetWeight,PetAge,PetGender,PetDesexed,PetWormed,PetVaccined,PetMicrochipped,PetEntryDate,[Version],ChangeDate,IsDeleted,UserChangeId)
VALUES (8,1,10,1,'Khỉ','Khỉ đột núi Đông Dương',40.0,40,1,1,1,0,0,GETDATE(),0,GETDATE(),0,'b5566616-7c6c-462f-a9da-970041488ade')
go

INSERT INTO PetAudits (PetId,VolunteerId,LocationId,OwnerId,PetName,PetDescription,PetWeight,PetAge,PetGender,PetDesexed,PetWormed,PetVaccined,PetMicrochipped,PetEntryDate,[Version],ChangeDate,IsDeleted,UserChangeId)
VALUES (9,3,20,3,'Chim Sẻ','Chim Sẻ nhà',0.05,1,1,1,1,1,1,GETDATE(),0,GETDATE(), 0,'7abf45ff-e629-4205-a147-4f68605cea33')
go

INSERT INTO PetAudits (PetId,VolunteerId,LocationId,OwnerId,PetName,PetDescription,PetWeight,PetAge,PetGender,PetDesexed,PetWormed,PetVaccined,PetMicrochipped,PetEntryDate,[Version],ChangeDate,IsDeleted,UserChangeId)
VALUES (10,1,1,1,'Tắc kè hoa','Tắc kè hoa Châu Phi',2.5,2,0,1,1,0,1,GETDATE(),0,GETDATE(),0,'b553ce16-7c6c-462f-a9da-97fgh1488ade')
go

/* pet color */
insert into PetColours (petId, colourId, isDeleted) values (14, 17, 0)
go
insert into PetColours (petId, colourId, isDeleted) values (10, 24, 0)
go
insert into PetColours (petId, colourId, isDeleted) values (11, 54, 0)
go
insert into PetColours (petId, colourId, isDeleted) values (19, 10, 0)
go
insert into PetColours (petId, colourId, isDeleted) values (11, 6, 0)
go
insert into PetColours (petId, colourId, isDeleted) values (20, 5, 0)
go
insert into PetColours (petId, colourId, isDeleted) values (4, 22, 0)
go
insert into PetColours (petId, colourId, isDeleted) values (15, 49, 0)
go
insert into PetColours (petId, colourId, isDeleted) values (9, 49, 0)
go
insert into PetColours (petId, colourId, isDeleted) values (15, 28, 0)
go
insert into PetColours (petId, colourId, isDeleted) values (7, 17, 0)
go
insert into PetColours (petId, colourId, isDeleted) values (15, 33, 0)
go
insert into PetColours (petId, colourId, isDeleted) values (11, 39, 0)
go
insert into PetColours (petId, colourId, isDeleted) values (3, 44, 0)
go
insert into PetColours (petId, colourId, isDeleted) values (13, 41, 0)
go
insert into PetColours (petId, colourId, isDeleted) values (1, 21, 0)
go
insert into PetColours (petId, colourId, isDeleted) values (11, 51, 0)
go
insert into PetColours (petId, colourId, isDeleted) values (4, 44, 0)
go
insert into PetColours (petId, colourId, isDeleted) values (15, 40, 0)
go
insert into PetColours (petId, colourId, isDeleted) values (1, 10, 0)
go
insert into PetColours (petId, colourId, isDeleted) values (15, 47, 0)
go
insert into PetColours (petId, colourId, isDeleted) values (13, 25, 0)
go
insert into PetColours (petId, colourId, isDeleted) values (10, 47, 0)
go
insert into PetColours (petId, colourId, isDeleted) values (14, 13, 0)
go
insert into PetColours (petId, colourId, isDeleted) values (5, 29, 0)
go
insert into PetColours (petId, colourId, isDeleted) values (14, 34, 0)
go
insert into PetColours (petId, colourId, isDeleted) values (8, 37, 0)
go
insert into PetColours (petId, colourId, isDeleted) values (15, 14, 0)
go
insert into PetColours (petId, colourId, isDeleted) values (7, 37, 0)
go
insert into PetColours (petId, colourId, isDeleted) values (10, 32, 0)
go
insert into PetColours (petId, colourId, isDeleted) values (3, 23, 0)
go
insert into PetColours (petId, colourId, isDeleted) values (17, 1, 0)
go
insert into PetColours (petId, colourId, isDeleted) values (9, 33, 0)
go
insert into PetColours (petId, colourId, isDeleted) values (11, 34, 0)
go
insert into PetColours (petId, colourId, isDeleted) values (11, 46, 0)
go
insert into PetColours (petId, colourId, isDeleted) values (15, 58, 0)
go
insert into PetColours (petId, colourId, isDeleted) values (17, 12, 0)
go
insert into PetColours (petId, colourId, isDeleted) values (6, 8, 0)
go
insert into PetColours (petId, colourId, isDeleted) values (3, 46, 0)
go
insert into PetColours (petId, colourId, isDeleted) values (19, 47, 0)
go
insert into PetColours (petId, colourId, isDeleted) values (9, 7, 0)
go
insert into PetColours (petId, colourId, isDeleted) values (6, 19, 0)
go
insert into PetColours (petId, colourId, isDeleted) values (7, 35, 0)
go
insert into PetColours (petId, colourId, isDeleted) values (20, 38, 0)
go
insert into PetColours (petId, colourId, isDeleted) values (12, 9, 0)
go
insert into PetColours (petId, colourId, isDeleted) values (20, 58, 0)
go
insert into PetColours (petId, colourId, isDeleted) values (14, 32, 0)
go
insert into PetColours (petId, colourId, isDeleted) values (10, 44, 0)
go
insert into PetColours (petId, colourId, isDeleted) values (4, 46, 0)
go
insert into PetColours (petId, colourId, isDeleted) values (10, 41, 0)
go

/* pet breed */
insert into PetBreeds (BreedId, PetId, IsDeleted) values (23, 14, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (6, 1, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (12, 6, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (8, 17, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (20, 1, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (9, 19, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (4, 19, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (12, 10, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (14, 17, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (13, 2, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (16, 20, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (11, 3, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (7, 15, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (19, 10, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (15, 1, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (18, 9, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (2, 1, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (12, 19, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (10, 15, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (14, 16, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (10, 8, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (17, 9, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (7, 6, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (19, 6, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (17, 4, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (6, 20, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (17, 7, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (21, 4, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (25, 5, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (19, 2, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (9, 7, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (2, 16, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (12, 15, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (1, 5, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (12, 18, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (16, 8, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (2, 6, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (17, 1, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (8, 4, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (6, 13, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (1, 2, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (21, 5, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (20, 12, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (5, 2, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (4, 18, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (6, 5, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (20, 14, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (23, 4, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (6, 16, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (13, 1, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (25, 10, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (23, 19, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (6, 6, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (16, 1, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (7, 5, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (20, 4, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (19, 13, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (9, 2, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (1, 3, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (20, 19, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (25, 13, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (22, 4, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (20, 9, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (2, 19, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (4, 7, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (25, 15, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (6, 3, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (19, 20, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (6, 4, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (12, 7, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (23, 20, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (21, 12, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (9, 12, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (10, 4, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (16, 6, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (17, 12, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (14, 13, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (24, 4, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (10, 12, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (23, 7, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (8, 8, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (22, 16, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (2, 5, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (14, 4, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (17, 14, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (9, 14, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (15, 14, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (19, 12, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (18, 11, 0)
go
insert into PetBreeds (BreedId, PetId, IsDeleted) values (13, 15, 0)
go

/* donor pet */
insert into DonorPets (LastDonation, TotalDonation, IsDeleted, PetId, DonorId) values ('2017-08-04', 812.89, 0, 16, 3)
go
insert into DonorPets (LastDonation, TotalDonation, IsDeleted, PetId, DonorId) values ('2011-12-01', 544.7, 0, 9, 5)
go
insert into DonorPets (LastDonation, TotalDonation, IsDeleted, PetId, DonorId) values ('2021-10-17', 472.83, 0, 8, 2)
go
insert into DonorPets (LastDonation, TotalDonation, IsDeleted, PetId, DonorId) values ('2011-07-30', 922.62, 0, 12, 5)
go
insert into DonorPets (LastDonation, TotalDonation, IsDeleted, PetId, DonorId) values ('2014-10-22', 296.9, 0, 18, 4)
go
insert into DonorPets (LastDonation, TotalDonation, IsDeleted, PetId, DonorId) values ('2018-02-19', 818.68, 0, 16, 2)
go
insert into DonorPets (LastDonation, TotalDonation, IsDeleted, PetId, DonorId) values ('2024-01-03', 471.79, 0, 6, 5)
go
insert into DonorPets (LastDonation, TotalDonation, IsDeleted, PetId, DonorId) values ('2017-03-27', 564.86, 0, 8, 1)
go
insert into DonorPets (LastDonation, TotalDonation, IsDeleted, PetId, DonorId) values ('2014-04-17', 363.43, 0, 2, 2)
go
insert into DonorPets (LastDonation, TotalDonation, IsDeleted, PetId, DonorId) values ('2017-11-18', 675.77, 0, 9, 1)
go
insert into DonorPets (LastDonation, TotalDonation, IsDeleted, PetId, DonorId) values ('2020-09-21', 544.9, 0, 8, 4)
go
insert into DonorPets (LastDonation, TotalDonation, IsDeleted, PetId, DonorId) values ('2013-01-08', 733.38, 0, 2, 4)
go
insert into DonorPets (LastDonation, TotalDonation, IsDeleted, PetId, DonorId) values ('2017-08-08', 802.05, 0, 1, 2)
go
insert into DonorPets (LastDonation, TotalDonation, IsDeleted, PetId, DonorId) values ('2013-04-26', 725.07, 0, 9, 2)
go
insert into DonorPets (LastDonation, TotalDonation, IsDeleted, PetId, DonorId) values ('2010-11-14', 762.88, 0, 6, 3)
go
insert into DonorPets (LastDonation, TotalDonation, IsDeleted, PetId, DonorId) values ('2023-12-26', 456.26, 0, 8, 5)
go
insert into DonorPets (LastDonation, TotalDonation, IsDeleted, PetId, DonorId) values ('2012-06-18', 869.4, 0, 15, 1)
go
insert into DonorPets (LastDonation, TotalDonation, IsDeleted, PetId, DonorId) values ('2011-01-21', 369.15, 0, 12, 4)
go
insert into DonorPets (LastDonation, TotalDonation, IsDeleted, PetId, DonorId) values ('2018-04-10', 869.42, 0, 17, 1)
go
insert into DonorPets (LastDonation, TotalDonation, IsDeleted, PetId, DonorId) values ('2014-09-05', 834.74, 0, 1, 5)
go
insert into DonorPets (LastDonation, TotalDonation, IsDeleted, PetId, DonorId) values ('2022-12-02', 873.11, 0, 17, 2)
go
insert into DonorPets (LastDonation, TotalDonation, IsDeleted, PetId, DonorId) values ('2021-11-27', 827.08, 0, 18, 5)
go
insert into DonorPets (LastDonation, TotalDonation, IsDeleted, PetId, DonorId) values ('2015-09-22', 794.92, 0, 4, 3)
go
insert into DonorPets (LastDonation, TotalDonation, IsDeleted, PetId, DonorId) values ('2024-02-20', 348.61, 0, 3, 3)
go
insert into DonorPets (LastDonation, TotalDonation, IsDeleted, PetId, DonorId) values ('2011-09-30', 393.1, 0, 7, 5)
go
insert into DonorPets (LastDonation, TotalDonation, IsDeleted, PetId, DonorId) values ('2021-12-07', 820.61, 0, 13, 5)
go
insert into DonorPets (LastDonation, TotalDonation, IsDeleted, PetId, DonorId) values ('2015-12-13', 261.94, 0, 17, 4)
go
insert into DonorPets (LastDonation, TotalDonation, IsDeleted, PetId, DonorId) values ('2023-05-17', 333.26, 0, 7, 4)
go
insert into DonorPets (LastDonation, TotalDonation, IsDeleted, PetId, DonorId) values ('2019-08-24', 940.35, 0, 3, 5)
go
insert into DonorPets (LastDonation, TotalDonation, IsDeleted, PetId, DonorId) values ('2020-08-17', 485.73, 0, 4, 5)
go
insert into DonorPets (LastDonation, TotalDonation, IsDeleted, PetId, DonorId) values ('2016-01-27', 424.97, 0, 16, 5)
go
insert into DonorPets (LastDonation, TotalDonation, IsDeleted, PetId, DonorId) values ('2020-02-02', 917.06, 0, 17, 3)
go
insert into DonorPets (LastDonation, TotalDonation, IsDeleted, PetId, DonorId) values ('2023-10-13', 696.56, 0, 19, 2)
go
insert into DonorPets (LastDonation, TotalDonation, IsDeleted, PetId, DonorId) values ('2018-03-03', 716.71, 0, 18, 2)
go
insert into DonorPets (LastDonation, TotalDonation, IsDeleted, PetId, DonorId) values ('2021-12-03', 419.14, 0, 15, 2)
go
insert into DonorPets (LastDonation, TotalDonation, IsDeleted, PetId, DonorId) values ('2012-01-03', 451.47, 0, 13, 2)
go
insert into DonorPets (LastDonation, TotalDonation, IsDeleted, PetId, DonorId) values ('2017-06-05', 412.66, 0, 18, 3)
go
insert into DonorPets (LastDonation, TotalDonation, IsDeleted, PetId, DonorId) values ('2021-02-04', 820.36, 0, 19, 4)
go
insert into DonorPets (LastDonation, TotalDonation, IsDeleted, PetId, DonorId) values ('2014-05-20', 201.72, 0, 20, 4)
go
insert into DonorPets (LastDonation, TotalDonation, IsDeleted, PetId, DonorId) values ('2014-04-19', 976.05, 0, 10, 2)
go
insert into DonorPets (LastDonation, TotalDonation, IsDeleted, PetId, DonorId) values ('2022-01-10', 275.25, 0, 17, 5)
go
insert into DonorPets (LastDonation, TotalDonation, IsDeleted, PetId, DonorId) values ('2014-05-01', 351.34, 0, 4, 2)
go
insert into DonorPets (LastDonation, TotalDonation, IsDeleted, PetId, DonorId) values ('2010-01-27', 802.27, 0, 6, 4)
go
insert into DonorPets (LastDonation, TotalDonation, IsDeleted, PetId, DonorId) values ('2010-12-01', 627.17, 0, 1, 1)
go

/* donor pet audit */
--select * from DonorPetAudits
insert into DonorPetAudits (LastDonation, [Version], NewTotalDonation, OldTotalDonation, IsDeleted, DonorId, PetId) values ('2008-06-30', 1, 556.62, 624.01, 0, 2, 19);
insert into DonorPetAudits (LastDonation, [Version], NewTotalDonation, OldTotalDonation, IsDeleted, DonorId, PetId) values ('2020-11-09', 1, 658.56, 853.21, 0, 4, 5);
insert into DonorPetAudits (LastDonation, [Version], NewTotalDonation, OldTotalDonation, IsDeleted, DonorId, PetId) values ('2017-03-18', 1, 500.95, 538.67, 0, 2, 1);
insert into DonorPetAudits (LastDonation, [Version], NewTotalDonation, OldTotalDonation, IsDeleted, DonorId, PetId) values ('2022-11-05', 1, 744.11, 744.07, 0, 4, 7);
insert into DonorPetAudits (LastDonation, [Version], NewTotalDonation, OldTotalDonation, IsDeleted, DonorId, PetId) values ('2011-01-17', 1, 714.18, 789.86, 0, 4, 4);
insert into DonorPetAudits (LastDonation, [Version], NewTotalDonation, OldTotalDonation, IsDeleted, DonorId, PetId) values ('2006-10-01', 1, 773.39, 590.6, 0, 5, 13);
insert into DonorPetAudits (LastDonation, [Version], NewTotalDonation, OldTotalDonation, IsDeleted, DonorId, PetId) values ('2008-03-20', 1, 556.78, 543.41, 0, 1, 16);
insert into DonorPetAudits (LastDonation, [Version], NewTotalDonation, OldTotalDonation, IsDeleted, DonorId, PetId) values ('2015-09-06', 1, 944.84, 526.62, 0, 2, 14);
insert into DonorPetAudits (LastDonation, [Version], NewTotalDonation, OldTotalDonation, IsDeleted, DonorId, PetId) values ('2013-10-16', 1, 612.61, 696.04, 0, 2, 4);
insert into DonorPetAudits (LastDonation, [Version], NewTotalDonation, OldTotalDonation, IsDeleted, DonorId, PetId) values ('2017-01-28', 1, 761.93, 857.36, 0, 4, 1);
insert into DonorPetAudits (LastDonation, [Version], NewTotalDonation, OldTotalDonation, IsDeleted, DonorId, PetId) values ('2011-01-25', 1, 870.57, 870.72, 0, 5, 10);
insert into DonorPetAudits (LastDonation, [Version], NewTotalDonation, OldTotalDonation, IsDeleted, DonorId, PetId) values ('2006-03-21', 1, 569.61, 942.41, 0, 2, 10);
insert into DonorPetAudits (LastDonation, [Version], NewTotalDonation, OldTotalDonation, IsDeleted, DonorId, PetId) values ('2006-08-24', 1, 614.64, 908.04, 0, 3, 12);
insert into DonorPetAudits (LastDonation, [Version], NewTotalDonation, OldTotalDonation, IsDeleted, DonorId, PetId) values ('2020-04-23', 1, 895.8, 865.5, 0, 4, 15);
insert into DonorPetAudits (LastDonation, [Version], NewTotalDonation, OldTotalDonation, IsDeleted, DonorId, PetId) values ('2009-07-12', 1, 874.62, 894.1, 0, 4, 11);
insert into DonorPetAudits (LastDonation, [Version], NewTotalDonation, OldTotalDonation, IsDeleted, DonorId, PetId) values ('2003-08-25', 1, 656.84, 674.1, 0, 1, 7);
insert into DonorPetAudits (LastDonation, [Version], NewTotalDonation, OldTotalDonation, IsDeleted, DonorId, PetId) values ('2023-12-16', 1, 966.74, 581.26, 0, 2, 8);
insert into DonorPetAudits (LastDonation, [Version], NewTotalDonation, OldTotalDonation, IsDeleted, DonorId, PetId) values ('2005-01-03', 1, 575.4, 696.98, 0, 2, 6);
insert into DonorPetAudits (LastDonation, [Version], NewTotalDonation, OldTotalDonation, IsDeleted, DonorId, PetId) values ('2007-11-07', 1, 891.83, 524.97, 0, 1, 14);
insert into DonorPetAudits (LastDonation, [Version], NewTotalDonation, OldTotalDonation, IsDeleted, DonorId, PetId) values ('2003-10-24', 1, 828.59, 510.31, 0, 5, 19);
insert into DonorPetAudits (LastDonation, [Version], NewTotalDonation, OldTotalDonation, IsDeleted, DonorId, PetId) values ('2018-09-29', 1, 835.21, 527.36, 0, 3, 7);
insert into DonorPetAudits (LastDonation, [Version], NewTotalDonation, OldTotalDonation, IsDeleted, DonorId, PetId) values ('2017-01-08', 1, 868.63, 669.56, 0, 5, 15);
insert into DonorPetAudits (LastDonation, [Version], NewTotalDonation, OldTotalDonation, IsDeleted, DonorId, PetId) values ('2008-10-30', 1, 501.08, 837.88, 0, 1, 11);





/* volunteer audit */
insert into VolunteerAudits (OldStatus, NewStatus, LastChange, VolunteerId, UserId, UserChangeId, IsDeleted) values (1, 0, '2016-04-01', 2, '7abf45ff-e629-4205-a147-4f68605cea33', 'b553ce16-7c6c-462f-a9da-970041488ade', 0)
go
insert into VolunteerAudits (OldStatus, NewStatus, LastChange, VolunteerId, UserId, UserChangeId, IsDeleted) values (0, 0, '2018-10-17', 1, '7abf45ff-e629-4205-a147-4f68605cea33', 'b553ce16-7c6c-462f-a9da-970041488ade', 0)
go
insert into VolunteerAudits (OldStatus, NewStatus, LastChange, VolunteerId, UserId, UserChangeId, IsDeleted) values (1, 1, '2017-05-02', 3, 'b5566616-7c6c-462f-a9da-970041488ade', 'b553ce16-7c6c-462f-a9da-970041488ade', 0)
go
insert into VolunteerAudits (OldStatus, NewStatus, LastChange, VolunteerId, UserId, UserChangeId, IsDeleted) values (1, 0, '2020-06-25', 2, '7abf45ff-e629-4205-a147-4f68605cea33', 'b5566616-7c6c-462f-a9da-970041488ade', 0)
go
insert into VolunteerAudits (OldStatus, NewStatus, LastChange, VolunteerId, UserId, UserChangeId, IsDeleted) values (1, 0, '2023-02-04', 1, 'b553ce16-7c6c-462f-a9da-970041488ade', 'b5566616-7c6c-462f-a9da-970041488ade', 0)
go
insert into VolunteerAudits (OldStatus, NewStatus, LastChange, VolunteerId, UserId, UserChangeId, IsDeleted) values (0, 0, '2020-05-17', 3, '7abf45ff-e629-4205-a147-4f68605cea33', '7abf45ff-e629-4205-a147-4f68605cea33', 0)
go
insert into VolunteerAudits (OldStatus, NewStatus, LastChange, VolunteerId, UserId, UserChangeId, IsDeleted) values (1, 0, '2016-01-14', 3, '7abf45ff-e629-4205-a147-4f68605cea33', 'b5566616-7c6c-462f-a9da-970041488ade', 0)
go
insert into VolunteerAudits (OldStatus, NewStatus, LastChange, VolunteerId, UserId, UserChangeId, IsDeleted) values (1, 0, '2019-08-21', 3, 'b553ce16-7c6c-462f-a9da-97fgh1488ade', 'b5566616-7c6c-462f-a9da-970041488ade', 0)
go
insert into VolunteerAudits (OldStatus, NewStatus, LastChange, VolunteerId, UserId, UserChangeId, IsDeleted) values (1, 0, '2017-03-31', 2, 'b5566616-7c6c-462f-a9da-970041488ade', 'b553ce16-7c6c-462f-a9da-97fgh1488ade', 0)
go
insert into VolunteerAudits (OldStatus, NewStatus, LastChange, VolunteerId, UserId, UserChangeId, IsDeleted) values (0, 0, '2015-08-13', 2, '7abf45ff-e629-4205-a147-4f68605cea33', 'b553ce16-7c6c-462f-a9da-970041488ade', 0)
go
insert into VolunteerAudits (OldStatus, NewStatus, LastChange, VolunteerId, UserId, UserChangeId, IsDeleted) values (1, 1, '2021-07-11', 1, 'b5566616-7c6c-462f-a9da-970041488ade', '7abf45ff-e629-4205-a147-4f68605cea33', 0)
go
insert into VolunteerAudits (OldStatus, NewStatus, LastChange, VolunteerId, UserId, UserChangeId, IsDeleted) values (1, 1, '2018-12-14', 1, 'b553ce16-7c6c-462f-a9da-970041488ade', 'b553ce16-7c6c-462f-a9da-97fgh1488ade', 0)
go
insert into VolunteerAudits (OldStatus, NewStatus, LastChange, VolunteerId, UserId, UserChangeId, IsDeleted) values (1, 1, '2013-07-14', 3, 'b553ce16-7c6c-462f-a9da-970041488ade', 'b553ce16-7c6c-462f-a9da-970041488ade', 0)
go
insert into VolunteerAudits (OldStatus, NewStatus, LastChange, VolunteerId, UserId, UserChangeId, IsDeleted) values (1, 0, '2020-06-23', 2, '7abf45ff-e629-4205-a147-4f68605cea33', '7abf45ff-e629-4205-a147-4f68605cea33', 0)
go
insert into VolunteerAudits (OldStatus, NewStatus, LastChange, VolunteerId, UserId, UserChangeId, IsDeleted) values (1, 0, '2014-10-17', 2, '7abf45ff-e629-4205-a147-4f68605cea33', 'b553ce16-7c6c-462f-a9da-970041488ade', 0)
go
insert into VolunteerAudits (OldStatus, NewStatus, LastChange, VolunteerId, UserId, UserChangeId, IsDeleted) values (0, 0, '2023-04-20', 2, 'b5566616-7c6c-462f-a9da-970041488ade', 'b553ce16-7c6c-462f-a9da-97fgh1488ade', 0)
go
insert into VolunteerAudits (OldStatus, NewStatus, LastChange, VolunteerId, UserId, UserChangeId, IsDeleted) values (0, 0, '2018-03-28', 2, 'b5566616-7c6c-462f-a9da-970041488ade', 'b553ce16-7c6c-462f-a9da-970041488ade', 0)
go
insert into VolunteerAudits (OldStatus, NewStatus, LastChange, VolunteerId, UserId, UserChangeId, IsDeleted) values (0, 1, '2017-05-19', 3, '7abf45ff-e629-4205-a147-4f68605cea33', 'b553ce16-7c6c-462f-a9da-970041488ade', 0)
go
insert into VolunteerAudits (OldStatus, NewStatus, LastChange, VolunteerId, UserId, UserChangeId, IsDeleted) values (0, 0, '2010-11-20', 1, 'b553ce16-7c6c-462f-a9da-970041488ade', 'b553ce16-7c6c-462f-a9da-970041488ade', 0)
go
insert into VolunteerAudits (OldStatus, NewStatus, LastChange, VolunteerId, UserId, UserChangeId, IsDeleted) values (0, 1, '2016-10-05', 2, 'b5566616-7c6c-462f-a9da-970041488ade', '7abf45ff-e629-4205-a147-4f68605cea33', 0)
go
insert into VolunteerAudits (OldStatus, NewStatus, LastChange, VolunteerId, UserId, UserChangeId, IsDeleted) values (1, 1, '2018-03-17', 1, 'b553ce16-7c6c-462f-a9da-970041488ade', 'b553ce16-7c6c-462f-a9da-97fgh1488ade', 0)
go
insert into VolunteerAudits (OldStatus, NewStatus, LastChange, VolunteerId, UserId, UserChangeId, IsDeleted) values (0, 0, '2011-05-17', 3, 'b5566616-7c6c-462f-a9da-970041488ade', '7abf45ff-e629-4205-a147-4f68605cea33', 0)
go
insert into VolunteerAudits (OldStatus, NewStatus, LastChange, VolunteerId, UserId, UserChangeId, IsDeleted) values (0, 1, '2016-09-10', 3, '7abf45ff-e629-4205-a147-4f68605cea33', 'b5566616-7c6c-462f-a9da-970041488ade', 0)
go
insert into VolunteerAudits (OldStatus, NewStatus, LastChange, VolunteerId, UserId, UserChangeId, IsDeleted) values (0, 0, '2023-12-20', 3, 'b5566616-7c6c-462f-a9da-970041488ade', '7abf45ff-e629-4205-a147-4f68605cea33', 0)
go
insert into VolunteerAudits (OldStatus, NewStatus, LastChange, VolunteerId, UserId, UserChangeId, IsDeleted) values (1, 0, '2016-04-02', 1, 'b553ce16-7c6c-462f-a9da-97fgh1488ade', '7abf45ff-e629-4205-a147-4f68605cea33', 0)
go
insert into VolunteerAudits (OldStatus, NewStatus, LastChange, VolunteerId, UserId, UserChangeId, IsDeleted) values (0, 1, '2023-11-10', 3, '7abf45ff-e629-4205-a147-4f68605cea33', '7abf45ff-e629-4205-a147-4f68605cea33', 0)
go
insert into VolunteerAudits (OldStatus, NewStatus, LastChange, VolunteerId, UserId, UserChangeId, IsDeleted) values (1, 1, '2019-09-15', 3, '7abf45ff-e629-4205-a147-4f68605cea33', 'b5566616-7c6c-462f-a9da-970041488ade', 0)
go
insert into VolunteerAudits (OldStatus, NewStatus, LastChange, VolunteerId, UserId, UserChangeId, IsDeleted) values (0, 1, '2020-01-20', 1, 'b553ce16-7c6c-462f-a9da-97fgh1488ade', 'b5566616-7c6c-462f-a9da-970041488ade', 0)
go
insert into VolunteerAudits (OldStatus, NewStatus, LastChange, VolunteerId, UserId, UserChangeId, IsDeleted) values (1, 1, '2016-09-21', 2, 'b5566616-7c6c-462f-a9da-970041488ade', '7abf45ff-e629-4205-a147-4f68605cea33', 0)
go
insert into VolunteerAudits (OldStatus, NewStatus, LastChange, VolunteerId, UserId, UserChangeId, IsDeleted) values (1, 0, '2020-04-28', 2, 'b553ce16-7c6c-462f-a9da-970041488ade', 'b553ce16-7c6c-462f-a9da-970041488ade', 0)
go
insert into VolunteerAudits (OldStatus, NewStatus, LastChange, VolunteerId, UserId, UserChangeId, IsDeleted) values (1, 0, '2017-06-26', 2, 'b553ce16-7c6c-462f-a9da-97fgh1488ade', '7abf45ff-e629-4205-a147-4f68605cea33', 0)
go
insert into VolunteerAudits (OldStatus, NewStatus, LastChange, VolunteerId, UserId, UserChangeId, IsDeleted) values (0, 1, '2021-11-23', 2, 'b553ce16-7c6c-462f-a9da-970041488ade', 'b553ce16-7c6c-462f-a9da-970041488ade', 0)
go
insert into VolunteerAudits (OldStatus, NewStatus, LastChange, VolunteerId, UserId, UserChangeId, IsDeleted) values (1, 1, '2020-07-31', 2, 'b553ce16-7c6c-462f-a9da-97fgh1488ade', '7abf45ff-e629-4205-a147-4f68605cea33', 0)
go
insert into VolunteerAudits (OldStatus, NewStatus, LastChange, VolunteerId, UserId, UserChangeId, IsDeleted) values (1, 1, '2018-04-09', 3, 'b553ce16-7c6c-462f-a9da-97fgh1488ade', '7abf45ff-e629-4205-a147-4f68605cea33', 0)
go
insert into VolunteerAudits (OldStatus, NewStatus, LastChange, VolunteerId, UserId, UserChangeId, IsDeleted) values (0, 1, '2011-01-13', 2, 'b5566616-7c6c-462f-a9da-970041488ade', '7abf45ff-e629-4205-a147-4f68605cea33', 0)
go
insert into VolunteerAudits (OldStatus, NewStatus, LastChange, VolunteerId, UserId, UserChangeId, IsDeleted) values (1, 0, '2016-07-21', 2, 'b553ce16-7c6c-462f-a9da-97fgh1488ade', 'b5566616-7c6c-462f-a9da-970041488ade', 0)
go
insert into VolunteerAudits (OldStatus, NewStatus, LastChange, VolunteerId, UserId, UserChangeId, IsDeleted) values (1, 0, '2020-04-15', 1, '7abf45ff-e629-4205-a147-4f68605cea33', 'b553ce16-7c6c-462f-a9da-97fgh1488ade', 0)
go
insert into VolunteerAudits (OldStatus, NewStatus, LastChange, VolunteerId, UserId, UserChangeId, IsDeleted) values (0, 0, '2011-06-16', 2, 'b553ce16-7c6c-462f-a9da-970041488ade', 'b553ce16-7c6c-462f-a9da-970041488ade', 0)
go
insert into VolunteerAudits (OldStatus, NewStatus, LastChange, VolunteerId, UserId, UserChangeId, IsDeleted) values (0, 1, '2014-08-25', 2, 'b553ce16-7c6c-462f-a9da-97fgh1488ade', 'b553ce16-7c6c-462f-a9da-970041488ade', 0)
go
insert into VolunteerAudits (OldStatus, NewStatus, LastChange, VolunteerId, UserId, UserChangeId, IsDeleted) values (1, 0, '2015-05-19', 3, 'b553ce16-7c6c-462f-a9da-97fgh1488ade', 'b553ce16-7c6c-462f-a9da-970041488ade', 0)
go

/* volunteer role */
insert into VolunteerRoles([Name],[Description],IsDeleted) Values(N'Foster', N'Foster là người giúp nhóm chăm sóc tạm thời trong thời gian các bé chưa tìm được chủ. Đây có thể là các bé khỏe mạnh hoặc cần chăm sóc đặc biệt hơn. Nếu bạn không thể nhận nuôi, hãy mở cửa để cho các bé một mái ấm tạm thời, giúp các bé khỏe mạnh hơn, ngoan ngoãn hơn cũng như tận hưởng tình thương từ một người yêu động vật, đồng thời giúp chúng tôi giảm tải khối lượng công việc.', 0)
go
insert into VolunteerRoles([Name],[Description],IsDeleted) Values(N'Dọn Dẹp Nhà Chung', N'Các bé chó mèo sau khi được cứu hộ và đã ổn định sẽ được chuyển về nhà chung trong quá trình chờ tìm chủ/foster. Các bé cần người giúp cho ăn uống đúng chế độ, dọn dẹp và chăm sóc y tế nếu cần. Tình nguyện viên nhà chung đảm nhận khối lượng công việc lớn khi phải quản lý khoảng 70 bé mèo và hơn 10 bé chó. Công việc này cần tính kiên nhẫn, cẩn thận, trách nhiệm cao và có tình thương với chó mèo. Tình nguyện viên có thể đăng ký giúp theo buổi lẻ. Với những người có thể làm cố định theo ca và làm 5 ngày mỗi tuần có thể được nhận trợ cấp công việc.', 0)
go
insert into VolunteerRoles([Name],[Description],IsDeleted) Values(N'Cứu Hộ', N'Khi một bé chó hay mèo gặp nạn, cần cứu các bé càng sớm càng tốt để tránh trường hợp các bé lang thang gặp kẻ xấu hoặc bị xe tông. Vì thế, Tình nguyện viên cứu hộ đóng vai trò quan trọng trong việc các bé có sống sót và được giải cứu kịp thời hay không. Công việc này đòi hỏi việc di chuyển bất ngờ, thậm chí vào đêm khuya hay ngày nghỉ, có thể phải đi xa. Ngoài ra, Tình nguyện viên cũng cần được trang bị kiến thức để bảo đảm an toàn cho bản thân khi cứu hộ.', 0)
go
insert into VolunteerRoles([Name],[Description],IsDeleted) Values(N'Vận Chuyển', N'Ngoài các tình huống cứu hộ, Hanoi Pet Adoption còn cần các bạn giúp vận chuyển chó/mèo từ nhà chung tới bệnh viện, nhà foster hoặc chủ nuôi v.v... Hoặc nhận đồ quyên góp cho Nhóm và chuyển về nhà chung.', 0)
go

/* volunteer x volunteer-role */
insert into VolunteerRoleXVolunteers(VolunteerId,RoleId,IsDeleted) Values(1,1,0)
go
insert into VolunteerRoleXVolunteers(VolunteerId,RoleId,IsDeleted) Values(2,2,0)
go
insert into VolunteerRoleXVolunteers(VolunteerId,RoleId,IsDeleted) Values(3,3,0)
go



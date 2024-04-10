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
select count(*) from Breeds
-- Chó
insert INTO Breeds(BreedName,[Description],ThumbPath,IsDeleted) VALUES (N"Affenpinscher",N"Affenpinscher có vẻ ngoài gần giống với một con khỉ, với khuôn mặt ngắn và bộ lông nổi bật. Chúng thường được biết đến với tính cách tự tin, năng động và yêu thích sự chú ý từ chủ nhân.","/",0);
insert INTO Breeds(BreedName,[Description],ThumbPath,IsDeleted) VALUES (N"Akita",N"Akita là một giống chó lớn, mạnh mẽ và có tính cách rất độc lập. Chúng thường rất trung thành và bảo vệ gia đình, nhưng cũng có thể khá cứng đầu và đòi hỏi người chủ có kinh nghiệm.","/",0);
insert INTO Breeds(BreedName,[Description],ThumbPath,IsDeleted) VALUES (N"Akbash",N"Akbash là một giống chó chăn cừu với bộ lông màu trắng tinh khôi. Chúng thường được sử dụng làm chó bảo vệ hoặc chó chăn cừu do tính cách trung thành và sự độc lập.","/",0); 
insert INTO Breeds(BreedName,[Description],ThumbPath,IsDeleted) VALUES (N"Aussiedoodle",N"Aussiedoodle là kết hợp giữa Australian Shepherd và Poodle. Chúng có bộ lông mượt mà và thông minh từ hai giống cha mẹ. Aussiedoodle thường là những người bạn trung thành, thông minh và hoạt bát.","/",0);
insert INTO Breeds(BreedName,[Description],ThumbPath,IsDeleted) VALUES (N"Basenji",N"Basenji được biết đến với tiếng sủa độc đáo, mà có thể được mô tả như tiếng "baroo". Họ là những chó săn nhỏ với bộ lông mịn và tính cách năng động. Basenji cũng thường rất sạch sẽ và có thể tự dọn dẹp bản thân giống như mèo.","/",0);

-- Mèo
insert INTO Breeds(BreedName,[Description],ThumbPath,IsDeleted) VALUES ("Abyssinian","Abyssinian có bộ lông ngắn và dày, với màu sắc đa dạng và mắt lớn, sáng bóng. Chúng thường có tính cách hiếu động, sáng tạo và thích khám phá.","/",0);
insert INTO Breeds(BreedName,[Description],ThumbPath,IsDeleted) VALUES ("Burmese","Mèo Burmese có bộ lông ngắn mịn và mắt to, nổi bật. Chúng thường rất âu yếm, trìu mến và thích gắn bó với con người.","/",0);
insert INTO Breeds(BreedName,[Description],ThumbPath,IsDeleted) VALUES ("Calico","Calico là một mẫu lông, không phải là một giống cụ thể. Chúng được đặc trưng bởi ba màu chính: đỏ, trắng và đen. Mèo Calico có thể thuộc nhiều giống khác nhau, nhưng thường được biết đến với tính cách đa dạng và vui vẻ.","/",0); 
insert INTO Breeds(BreedName,[Description],ThumbPath,IsDeleted) VALUES ("Chartreux","Chartreux là một giống mèo có bộ lông dày, màu xám xanh hoặc xám xanh dương. Chúng thường rất thân thiện, nhưng cũng có thể độc lập và thích giữ khoảng cách.","/",0);
insert INTO Breeds(BreedName,[Description],ThumbPath,IsDeleted) VALUES ("Balinese","Balinese là phiên bản dài tóc của mèo Siamese. Chúng có bộ lông dài, mềm mại và màu sắc đa dạng. Balinese thường thông minh, yêu thương và thích thể hiện sự chú ý.","/",0);

-- Thỏa
insert INTO Breeds(BreedName,[Description],ThumbPath,IsDeleted) VALUES ("Angora Rabbit","Angora Rabbit nổi tiếng với bộ lông dài, mịn và mềm mại. Chúng thường cần chăm sóc đặc biệt để giữ cho bộ lông không bị rối và giữ ấm. Angora thường rất hiền lành và thích được chăm sóc.","/",0);
insert INTO Breeds(BreedName,[Description],ThumbPath,IsDeleted) VALUES ("Beveren","Beveren là một giống thỏ có kích thước lớn và có bộ lông ngắn mịn. Chúng có thể có màu sắc khác nhau như xanh, đen, đỏ và trắng. Beveren thường có tính cách bình tĩnh và thân thiện.","/",0);
insert INTO Breeds(BreedName,[Description],ThumbPath,IsDeleted) VALUES ("Belgian Hare","Belgian Hare là một giống thỏ có hình dáng svelte và bộ lông ngắn mượt. Chúng thường rất nhanh nhẹn, năng động và thích vận động.","/",0); 
insert INTO Breeds(BreedName,[Description],ThumbPath,IsDeleted) VALUES ("Britannia Petite","Britannia Petite là một giống thỏ nhỏ, nhưng năng động và nhanh nhẹn. Chúng có bộ lông ngắn và màu sắc đa dạng. Britannia Petite thường rất nhanh nhẹn và tò mò.","/",0);
insert INTO Breeds(BreedName,[Description],ThumbPath,IsDeleted) VALUES ("Checkered Giant","Checkered Giant là một giống thỏ lớn, có bộ lông ngắn mượt và màu sắc phân biệt rõ ràng. Chúng có thể có màu đen và trắng hoặc xám và trắng. Checkered Giant thường là những người bạn trung thành và hiền lành.","/",0);

-- Ngựa
insert INTO Breeds(BreedName,[Description],ThumbPath,IsDeleted) VALUES ("Appaloosa","Appaloosa nổi tiếng với bộ lông có các đốm hay vệt màu trên nền lông màu sắc khác nhau. Chúng có vẻ ngoài đặc biệt và đa dạng về màu sắc. Appaloosa thường thông minh, linh hoạt và có khả năng làm việc tốt.","/",0);
insert INTO Breeds(BreedName,[Description],ThumbPath,IsDeleted) VALUES ("Arabian","Arabian là một trong những giống ngựa cổ điển nhất và được biết đến với vẻ ngoài tinh tế, dáng vẻ điển hình và sức bền vững. Chúng thường có đầu nhỏ, vòi sen và thân hình mảnh mai. Arabian là những người bạn trung thành, thông minh và nhanh nhẹn.","/",0);
insert INTO Breeds(BreedName,[Description],ThumbPath,IsDeleted) VALUES ("Belgian","Belgian là một giống ngựa nặng, mạnh mẽ và có bộ lông dày. Chúng thường được sử dụng cho công việc kéo, vận chuyển và canh tác. Belgian thường có tính cách trầm tĩnh, bền bỉ và trung thành.","/",0); 
insert INTO Breeds(BreedName,[Description],ThumbPath,IsDeleted) VALUES ("Clydesdale","Clydesdale là một giống ngựa lớn có bộ lông dày mạnh mẽ và thường có một vòng mảnh mai quanh cổ gọi là "bèo". Chúng thường được sử dụng cho công việc kéo và hiện đã trở thành biểu tượng cho các cuộc diễu hành và sự kiện. Clydesdale thường thông minh, nhanh nhẹn và dễ đào tạo.","/",0);
insert INTO Breeds(BreedName,[Description],ThumbPath,IsDeleted) VALUES ("Connemara","Connemara là một giống ngựa nhỏ có thân hình mạnh mẽ, chắc chắn và bộ lông dày. Chúng thường được biết đến với tính cách mạnh mẽ, can đảm và đa năng. Connemara thích hợp cho nhiều môn thể thao như cưỡi và nhảy vượt.","/",0);

-- Chim
insert INTO Breeds(BreedName,[Description],ThumbPath,IsDeleted) VALUES ("African Gre","","/",0);
insert INTO Breeds(BreedName,[Description],ThumbPath,IsDeleted) VALUES ("Brotogeris","","/",0);
insert INTO Breeds(BreedName,[Description],ThumbPath,IsDeleted) VALUES ("Button-Quail","","/",0); 
insert INTO Breeds(BreedName,[Description],ThumbPath,IsDeleted) VALUES ("Caique","","/",0);
insert INTO Breeds(BreedName,[Description],ThumbPath,IsDeleted) VALUES ("Canary","","/",0);




-- insert pets
INSERT INTO Pets(PetName, PetDescription, PetWeight, PetAge, PetGender, PetDesexed, PetWormed, PetVaccined, PetMicrochipped, PetEntryDate, [Status], IsDeleted, VolunteerId, LocationId, OwnerId, PetImgId) 
VALUES ('Chó','Loài động vật có sự đa dạng về kích thước, màu sắc và hình dạng, từ chó săn lớn đến chó nhỏ như chihuahua. Chúng thường được nuôi làm thú cưng hoặc làm công việc như canh gác, dẫn đường, hoặc làm nhiệm vụ cứu hộ. Sự trung thành và thông minh của chó đã làm cho chúng trở thành bạn đồng hành lý tưởng cho con người từ hàng ngàn năm nay.','/');





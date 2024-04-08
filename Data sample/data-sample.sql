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
delete from __EFMigrationsHistory
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

-- insert pets
INSERT INTO Pets VALUES('Chó','Loài động vật có sự đa dạng về kích thước, màu sắc và hình dạng, từ chó săn lớn đến chó nhỏ như chihuahua. Chúng thường được nuôi làm thú cưng hoặc làm công việc như canh gác, dẫn đường, hoặc làm nhiệm vụ cứu hộ. Sự trung thành và thông minh của chó đã làm cho chúng trở thành bạn đồng hành lý tưởng cho con người từ hàng ngàn năm nay.','/');

INSERT INTO Pets VALUES('Mèo','Loài động vật linh hoạt và nhanh nhẹn, mèo thường được nuôi làm thú cưng. Với khả năng săn mồi tốt và tính cách độc lập, chúng trở thành một phần không thể thiếu của nhiều gia đình trên toàn thế giới.','/');

INSERT INTO Pets VALUES('Thỏa','Thường được biết đến với bộ lông mềm mại và đôi tai dài, thỏ là loài động vật nhỏ bé và dễ thương. Chúng là thú cưng phổ biến với tính cách hiền lành và thân thiện, thường được nuôi trong nhà và yêu thích bởi nhiều người trên khắp thế giới.','/');

INSERT INTO Pets VALUES('Ngựa','Loài động vật có nguồn gốc từ các vùng đồng cỏ rộng lớn, ngựa đã được thuần hóa và sử dụng bởi con người từ hàng ngàn năm nay. Với sức mạnh và sự trung thành, ngựa không chỉ được sử dụng trong việc làm việc nông nghiệp mà còn trong các hoạt động thể thao và giải trí.','/');

INSERT INTO Pets VALUES('Chim','Tính đa dạng về hình dáng, màu sắc và hành vi, chim là loài động vật có khả năng bay. Chúng phân bố trên mọi châu lục và thích nghi với nhiều môi trường sống khác nhau, từ rừng rậm đến sa mạc và đồng cỏ. Chim không chỉ làm giàu sự đa dạng sinh học của hành tinh mà còn mang lại niềm vui cho người yêu thiên nhiên qua việc quan sát và nghiên cứu.','/');

-- insert colours
INSERT INTO Colours VALUES ('Apricot');
INSERT INTO Colours VALUES ('Beige');
INSERT INTO Colours VALUES ('Bicolor');
INSERT INTO Colours VALUES ('Black');
INSERT INTO Colours VALUES ('Brindle');
INSERT INTO Colours VALUES ('Golden');
INSERT INTO Colours VALUES ('Brown');
INSERT INTO Colours VALUES ('Harlequin');
INSERT INTO Colours VALUES ('Merle');
INSERT INTO Colours VALUES ('Chestnut');
INSERT INTO Colours VALUES ('Red');
INSERT INTO Colours VALUES ('Orange');
INSERT INTO Colours VALUES ('Sable');
INSERT INTO Colours VALUES ('Tricolor');
INSERT INTO Colours VALUES ('White');
INSERT INTO Colours VALUES ('Yellow');
INSERT INTO Colours VALUES ('Blond');
INSERT INTO Colours VALUES ('Tan');
INSERT INTO Colours VALUES ('Fawn');
INSERT INTO Colours VALUES ('Tuxedo');
INSERT INTO Colours VALUES ('Blue Point');
INSERT INTO Colours VALUES ('Buff');
INSERT INTO Colours VALUES ('Cream');
INSERT INTO Colours VALUES ('Dilute Tortoiseshell');
INSERT INTO Colours VALUES ('Flame Point');
INSERT INTO Colours VALUES ('Lilac Point');
INSERT INTO Colours VALUES ('Seal Point');
INSERT INTO Colours VALUES ('Smoke');
INSERT INTO Colours VALUES ('Tabby');
INSERT INTO Colours VALUES ('Tortoiseshell');
INSERT INTO Colours VALUES ('Silver Marten');
INSERT INTO Colours VALUES ('Agouti');
INSERT INTO Colours VALUES ('Albino');
INSERT INTO Colours VALUES ('Calico');
INSERT INTO Colours VALUES ('Appaloosa');
INSERT INTO Colours VALUES ('Bay');
INSERT INTO Colours VALUES ('Buckskin');
INSERT INTO Colours VALUES ('Champagne');
INSERT INTO Colours VALUES ('Sorrel');
INSERT INTO Colours VALUES ('Cremello');
INSERT INTO Colours VALUES ('Dun');
INSERT INTO Colours VALUES ('Dapple Gray');
INSERT INTO Colours VALUES ('Grullo');
INSERT INTO Colours VALUES ('Liver');
INSERT INTO Colours VALUES ('Paint');
INSERT INTO Colours VALUES ('Palomino');
INSERT INTO Colours VALUES ('Perlino');
INSERT INTO Colours VALUES ('Piebald');
INSERT INTO Colours VALUES ('Pinto');
INSERT INTO Colours VALUES ('Olive');
INSERT INTO Colours VALUES ('Violet');
INSERT INTO Colours VALUES ('Rust');
INSERT INTO Colours VALUES ('Rufous');
INSERT INTO Colours VALUES ('Iridescent');
INSERT INTO Colours VALUES ('Pink');
INSERT INTO Colours VALUES ('Purple');
INSERT INTO Colours VALUES ('Roan');
INSERT INTO Colours VALUES ('Spotteda');

-- insert PetColours
INSERT INTO PetColours VALUES ()
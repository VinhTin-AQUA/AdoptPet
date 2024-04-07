Create database AdoptPet
use AdoptPet
CREATE TABLE Breed (
    breed_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    breed_name NVARCHAR(254),
    description NVARCHAR(MAX),
    thumb_path NVARCHAR(MAX)
);

CREATE TABLE PetBreed (
    petbreed_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    breed_id INT,
    pet_id INT,
); -- nhieu nhieu

CREATE TABLE Colour (
    colour_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    colour_name NVARCHAR(20)
);

CREATE TABLE PetColor (
    pet_colour_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    pet_id INT
    colour_id_id INT
); -- nhieu nhieu

CREATE TABLE donors (
    donors_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    user_id INT,
    name NVARCHAR(50),
    location_id INT,
    total_donation DECIMAL(12,2)
);

CREATE TABLE donor_pet (
    donor_pet INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    pet_id INT,
    last_donation DATETIME NOT NULL DEFAULT GETDATE(),
    total_donation DECIMAL(12,2) NOT NULL DEFAULT 0.00
); -- nhieu nhieu

CREATE TABLE donor_pet_audit(
    audit_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    donor_id INT,
    pet_id INT,
    last_donation DATETIME,
    ver INT,
    new_total_donation decimal(12,2),
    old_total_donation decimal(12,2)
);
CREATE TABLE owner (
    owner_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    pet_id INT,
    name NVARCHAR(50),
    location_id INT
); 

CREATE TABLE Volunteer (
    volunteer_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    user_id INT,
    name NVARCHAR(50),
    date_start DATETIME,
    location_id INT,
    status TINYINT
);

CREATE TABLE Volunteer_audit (
    volunteer_audit_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    volunteer_id INT,
    user_id INT,
    old_status TINYINT,
    new_status TINYINT,
    last_change DATETIME,
    user_change_id INT
);

CREATE TABLE Location (
    location_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    street NVARCHAR(50),
    wards NVARCHAR(50),
    district_city NVARCHAR(50),
    province_city NVARCHAR(50),
    zip_code NVARCHAR(20)
);

CREATE TABLE volunteer_role (
    role_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    description NVARCHAR(MAX)
);

CREATE TABLE volunteer_role_x_volunteer (
    audit_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    volunteer_id INT,
    role_id NVARCHAR(50)
); -- nhieu nhieu

CREATE TABLE Pet (
    pet_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    pet_name CHAR(20),
    volunteer_id INT,
    location_id INT,
    owner_id INT,
    pet_description NVARCHAR(MAX),
    pet_weight DECIMAL(3,1),
    pet_age varchar(50),
    pet_gender BIT,
    pet_desexed TINYINT,
    pet_wormed TINYINT,
    pet_vaccined TINYINT,
    pet_microchipped TINYINT,
    pet_entryDate DATETIME,
    [status] TINYINT
);

CREATE TABLE PetImage (
    pet_img_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    img_path NVARCHAR(255),
    pet_id INT
);

CREATE TABLE pet_audit (
    pet_audit_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    pet_id INT,
    pet_name CHAR(20),
    volunteer_id INT,
    location_id INT,
    owner_id INT,
    pet_description NVARCHAR(MAX),
    pet_weight DECIMAL(3,1),
    pet_age varchar(50),
    pet_gender BIT,
    pet_desexed TINYINT,
    pet_wormed TINYINT,
    pet_vaccined TINYINT,
    pet_microchipped TINYINT,
    pet_entryDate DATETIME,
    [status] TINYINT,
    [version] INT,
    change_date DATETIME,
    user_change_id INT
);






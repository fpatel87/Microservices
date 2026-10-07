use ProductDb;
go

INSERT INTO Product_category (Id, Name, Parent_Category_Id) VALUES
(1, 'Electronics', NULL),
(2, 'Smartphones', 1),
(3, 'Laptops', 1),
(4, 'Tablets', 1),
(5, 'Cameras', 1),
(6, 'Audio', 1),
(7, 'Accessories', 1),
(8, 'Networking', 1),
(9, 'Gaming', 1),
(10, 'Smart Home', 1),
(11, 'Lighting', 1),
(12, 'Chargers', 1),
(13, 'Peripherals', 1),
(14, 'Storage', 1),
(15, 'Monitors', 1),
(16, 'Printers', 1),
(17, 'Virtual Reality', 1),
(18, 'Microphones', 1),
(19, 'Drones', 1),
(20, 'Projectors', 1);

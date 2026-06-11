-- ============================================================
--  Test-data för Storage.API
--  Täcker alla 8 kombinationer av IsPaid/IsDelivered/IsRefunded
--  (minst 2 ordrar per kombination = 16 ordrar totalt)
-- ============================================================

USE LexiconStore;

-- ------------------------------------------------------------
--  Customers  (3 st)
-- ------------------------------------------------------------
INSERT INTO Customer (Id, CreatedAt, UpdatedAt, IsActive, Name, Email, Phone, Address, City, Zip, Country, Notes) VALUES
('3148910a-b1c5-4268-aaad-ecd9c4fe03f6', '2024-06-01 08:00:00', '2024-06-01 08:00:00', 1, 'Anna Lindqvist',  'anna.lindqvist@example.se',  '070-123 45 67', 'Storgatan 12',    'Stockholm', 11122, 'Sverige', 'Stamkund sedan 2024'),
('0182483e-34cc-496e-8f90-5018c9a971e0', '2024-09-15 10:30:00', '2024-09-15 10:30:00', 1, 'Björn Karlsson',  'bjorn.karlsson@example.se',  '073-987 65 43', 'Verkstadsvägen 4', 'Göteborg',  41101, 'Sverige', NULL),
('993c8828-80cf-401d-93ff-4e052ce9227a', '2025-01-20 14:00:00', '2025-01-20 14:00:00', 0, 'Carina Holm',    'carina.holm@example.se',     '076-555 00 11', 'Industrigatan 7',  'Malmö',     21121, 'Sverige', 'Inaktivt konto – avslutad verksamhet');

-- ------------------------------------------------------------
--  Products  (20 st)
-- ------------------------------------------------------------
INSERT INTO Product (Name, Price, DiscountFixed, DiscountPercent, Category, Shelf, Count, Description, CreatedAt, UpdatedAt) VALUES
('Hammare 500g',           129.00, 0, 0, 'Verktyg',           'A1',  45,  'Stålhuvud med träskaft',              '2024-01-01 00:00:00', '2024-01-01 00:00:00'),
('Skruvmejsel Phillips',    49.00, 0, 0, 'Verktyg',           'A1',  80,  'PH2, 150 mm skaft',                   '2024-01-01 00:00:00', '2024-01-01 00:00:00'),
('Skruvmejsel Flathead',    45.00, 0, 0, 'Verktyg',           'A1',  75,  'Flat 6 mm, 150 mm skaft',             '2024-01-01 00:00:00', '2024-01-01 00:00:00'),
('Måttband 5m',             89.00, 0, 0, 'Mätverktyg',        'A2',  60,  'Automatisk inrullning',               '2024-01-01 00:00:00', '2024-01-01 00:00:00'),
('Vattenpass 60cm',        199.00, 0, 0, 'Mätverktyg',        'A2',  30,  'Aluminium med 3 bubbelnivåer',        '2024-01-01 00:00:00', '2024-01-01 00:00:00'),
('Borrmaskin 18V',        1299.00, 0, 0, 'Elverktyg',         'B1',  20,  'Borstlös motor, inkl. 2 batterier',   '2024-01-01 00:00:00', '2024-01-01 00:00:00'),
('Cirkelsåg 165mm',       1599.00, 0, 0, 'Elverktyg',         'B1',  15,  '5500 rpm, laserguide',                '2024-01-01 00:00:00', '2024-01-01 00:00:00'),
('Slipmaskin excentr.',    799.00, 0, 0, 'Elverktyg',         'B2',  18,  '125 mm, 12 000 rpm',                  '2024-01-01 00:00:00', '2024-01-01 00:00:00'),
('Skyddsglas klar',         59.00, 0, 0, 'Skyddsutrustning',  'C1', 100,  'EN166 certifierade',                  '2024-01-01 00:00:00', '2024-01-01 00:00:00'),
('Arbetshandskar L',        79.00, 0, 0, 'Skyddsutrustning',  'C1',  90,  'Skärskyddsnivå C',                    '2024-01-01 00:00:00', '2024-01-01 00:00:00'),
('Hörselskydd SNR30',      149.00, 0, 0, 'Skyddsutrustning',  'C2',  50,  'Vikbara, SNR 30 dB',                  '2024-01-01 00:00:00', '2024-01-01 00:00:00'),
('Skyddshjälm vit',        299.00, 0, 0, 'Skyddsutrustning',  'C2',  35,  'EN397, justerhuvud',                  '2024-01-01 00:00:00', '2024-01-01 00:00:00'),
('Spik 50mm 1kg',           49.00, 0, 0, 'Fästelement',       'D1', 200,  'Förzinkad, 1 kg förp.',               '2024-01-01 00:00:00', '2024-01-01 00:00:00'),
('Skruv 4x40 100-pack',     69.00, 0, 0, 'Fästelement',       'D1', 150,  'Rostfri A2',                          '2024-01-01 00:00:00', '2024-01-01 00:00:00'),
('Bult M8x60 10-pack',      59.00, 0, 0, 'Fästelement',       'D2',  80,  'Inkl. muttrar och brickor',           '2024-01-01 00:00:00', '2024-01-01 00:00:00'),
('Träskiva 18mm 120x60',   349.00, 0, 0, 'Trävaror',          'E1',  40,  'Björkplywood, slipat',                '2024-01-01 00:00:00', '2024-01-01 00:00:00'),
('Gipsskiva 13mm 120x60',  189.00, 0, 0, 'Byggmaterial',      'E2',  55,  'Standard, brandskyddad',              '2024-01-01 00:00:00', '2024-01-01 00:00:00'),
('Plastfilm 4m x 25m',     229.00, 0, 0, 'Byggmaterial',      'F1',  25,  'PE-folie 0,2 mm',                     '2024-01-01 00:00:00', '2024-01-01 00:00:00'),
('Pensel 50mm',              49.00, 0, 0, 'Målning',           'F2', 120,  'Syntetborst, lackpensel',             '2024-01-01 00:00:00', '2024-01-01 00:00:00'),
('Roller 18cm kit',         129.00, 0, 0, 'Målning',           'F2',  65,  'Inkl. bricka och 2 valsar',           '2024-01-01 00:00:00', '2024-01-01 00:00:00');

-- ------------------------------------------------------------
--  Orders  (16 st – 2 per kombination av IsPaid/IsDelivered/IsRefunded)
--  CustomerId fördelning: Anna=ord 1,2,3,4,7,8  Björn=ord 5,6,9,10,11,12  Carina=ord 13,14,15,16
-- ------------------------------------------------------------

--  Kombination 1: IsPaid=0 IsDelivered=0 IsRefunded=0
INSERT INTO [Order] (CreatedAt, UpdatedAt, CustomerId, Notes, DiscountFixed, DiscountPercent, IsPaid, PaidAt, IsDelivered, DeliveredAt, IsRefunded, RefundedAt) VALUES
('2025-01-10 09:15:00', '2025-01-10 09:15:00', '3148910a-b1c5-4268-aaad-ecd9c4fe03f6', 'Inväntar betalning',    0,    0,    0, NULL, 0, NULL, 0, NULL),
('2025-01-18 14:30:00', '2025-01-18 14:30:00', '3148910a-b1c5-4268-aaad-ecd9c4fe03f6', 'Webb-order, ej betald', 0,    0,    0, NULL, 0, NULL, 0, NULL);

--  Kombination 2: IsPaid=1 IsDelivered=0 IsRefunded=0
INSERT INTO [Order] (CreatedAt, UpdatedAt, CustomerId, Notes, DiscountFixed, DiscountPercent, IsPaid, PaidAt, IsDelivered, DeliveredAt, IsRefunded, RefundedAt) VALUES
('2025-02-03 10:00:00', '2025-02-03 10:05:00', '3148910a-b1c5-4268-aaad-ecd9c4fe03f6', 'Betald, väntar på lager',  0,  0, 1, '2025-02-03 10:05:00', 0, NULL, 0, NULL),
('2025-02-14 11:20:00', '2025-02-14 11:25:00', '3148910a-b1c5-4268-aaad-ecd9c4fe03f6', 'Expresslev. beställd',    50,  0, 1, '2025-02-14 11:25:00', 0, NULL, 0, NULL);

--  Kombination 3: IsPaid=0 IsDelivered=1 IsRefunded=0
INSERT INTO [Order] (CreatedAt, UpdatedAt, CustomerId, Notes, DiscountFixed, DiscountPercent, IsPaid, PaidAt, IsDelivered, DeliveredAt, IsRefunded, RefundedAt) VALUES
('2025-03-05 08:00:00', '2025-03-07 13:00:00', '0182483e-34cc-496e-8f90-5018c9a971e0', 'Faktura 30 dagar',           0, 0, 0, NULL, 1, '2025-03-07 13:00:00', 0, NULL),
('2025-03-20 09:45:00', '2025-03-22 10:00:00', '0182483e-34cc-496e-8f90-5018c9a971e0', 'Levererad, inväntar fakt.',  0, 0, 0, NULL, 1, '2025-03-22 10:00:00', 0, NULL);

--  Kombination 4: IsPaid=1 IsDelivered=1 IsRefunded=0
INSERT INTO [Order] (CreatedAt, UpdatedAt, CustomerId, Notes, DiscountFixed, DiscountPercent, IsPaid, PaidAt, IsDelivered, DeliveredAt, IsRefunded, RefundedAt) VALUES
('2025-04-01 10:30:00', '2025-04-03 14:00:00', '3148910a-b1c5-4268-aaad-ecd9c4fe03f6', 'Stamkund, 5% rabatt',  0, 0.05, 1, '2025-04-01 10:35:00', 1, '2025-04-03 14:00:00', 0, NULL),
('2025-04-15 13:00:00', '2025-04-17 09:00:00', '3148910a-b1c5-4268-aaad-ecd9c4fe03f6', 'Klar order',         100, 0,    1, '2025-04-15 13:02:00', 1, '2025-04-17 09:00:00', 0, NULL);

--  Kombination 5: IsPaid=0 IsDelivered=0 IsRefunded=1
INSERT INTO [Order] (CreatedAt, UpdatedAt, CustomerId, Notes, DiscountFixed, DiscountPercent, IsPaid, PaidAt, IsDelivered, DeliveredAt, IsRefunded, RefundedAt) VALUES
('2025-05-02 11:00:00', '2025-05-02 15:00:00', '0182483e-34cc-496e-8f90-5018c9a971e0', 'Order annullerad av kund',  0, 0, 0, NULL, 0, NULL, 1, '2025-05-02 15:00:00'),
('2025-05-10 09:00:00', '2025-05-10 09:30:00', '0182483e-34cc-496e-8f90-5018c9a971e0', 'Fellagd order, återbetald', 0, 0, 0, NULL, 0, NULL, 1, '2025-05-10 09:30:00');

--  Kombination 6: IsPaid=1 IsDelivered=0 IsRefunded=1
INSERT INTO [Order] (CreatedAt, UpdatedAt, CustomerId, Notes, DiscountFixed, DiscountPercent, IsPaid, PaidAt, IsDelivered, DeliveredAt, IsRefunded, RefundedAt) VALUES
('2025-06-01 08:30:00', '2025-06-03 10:00:00', '0182483e-34cc-496e-8f90-5018c9a971e0', 'Lagerslut – full återbet.', 0, 0, 1, '2025-06-01 08:35:00', 0, NULL, 1, '2025-06-03 10:00:00'),
('2025-06-12 14:00:00', '2025-06-13 09:00:00', '0182483e-34cc-496e-8f90-5018c9a971e0', 'Kund ångrade, återbet.',    0, 0, 1, '2025-06-12 14:10:00', 0, NULL, 1, '2025-06-13 09:00:00');

--  Kombination 7: IsPaid=0 IsDelivered=1 IsRefunded=1
INSERT INTO [Order] (CreatedAt, UpdatedAt, CustomerId, Notes, DiscountFixed, DiscountPercent, IsPaid, PaidAt, IsDelivered, DeliveredAt, IsRefunded, RefundedAt) VALUES
('2025-07-05 10:00:00', '2025-07-10 08:00:00', '993c8828-80cf-401d-93ff-4e052ce9227a', 'Reklamation, faktura makulerad', 0, 0, 0, NULL, 1, '2025-07-07 12:00:00', 1, '2025-07-10 08:00:00'),
('2025-07-20 11:30:00', '2025-07-25 09:00:00', '993c8828-80cf-401d-93ff-4e052ce9227a', 'Felleverat, kredit utfärdad',    0, 0, 0, NULL, 1, '2025-07-22 14:00:00', 1, '2025-07-25 09:00:00');

--  Kombination 8: IsPaid=1 IsDelivered=1 IsRefunded=1
INSERT INTO [Order] (CreatedAt, UpdatedAt, CustomerId, Notes, DiscountFixed, DiscountPercent, IsPaid, PaidAt, IsDelivered, DeliveredAt, IsRefunded, RefundedAt) VALUES
('2025-08-03 09:00:00', '2025-08-10 13:00:00', '993c8828-80cf-401d-93ff-4e052ce9227a', 'Retur, full återbetalning',   0, 0, 1, '2025-08-03 09:05:00', 1, '2025-08-05 11:00:00', 1, '2025-08-10 13:00:00'),
('2025-08-18 10:15:00', '2025-08-25 10:00:00', '993c8828-80cf-401d-93ff-4e052ce9227a', 'Defekt vara, återbet. gjord', 0, 0, 1, '2025-08-18 10:20:00', 1, '2025-08-20 15:00:00', 1, '2025-08-25 10:00:00');

-- ------------------------------------------------------------
--  OrderItems
-- ------------------------------------------------------------
-- Order 1
INSERT INTO OrderItem (OrderId, ProductId, Count, Price, DiscountFixed, DiscountPercent, Notes) VALUES
(1, 1,  2, 129.00, 0, 0, NULL),
(1, 9,  3,  59.00, 0, 0, NULL);
-- Order 2
INSERT INTO OrderItem (OrderId, ProductId, Count, Price, DiscountFixed, DiscountPercent, Notes) VALUES
(2, 6,  1, 1299.00, 0, 0, NULL),
(2, 8,  1,  799.00, 0, 0, NULL);
-- Order 3
INSERT INTO OrderItem (OrderId, ProductId, Count, Price, DiscountFixed, DiscountPercent, Notes) VALUES
(3, 13, 5,  49.00, 0, 0, NULL),
(3, 14, 3,  69.00, 0, 0, NULL),
(3, 15, 2,  59.00, 0, 0, NULL);
-- Order 4 (50 kr orderrabatt)
INSERT INTO OrderItem (OrderId, ProductId, Count, Price, DiscountFixed, DiscountPercent, Notes) VALUES
(4, 7,  1, 1599.00, 0, 0, NULL),
(4, 10, 2,   79.00, 0, 0, NULL);
-- Order 5
INSERT INTO OrderItem (OrderId, ProductId, Count, Price, DiscountFixed, DiscountPercent, Notes) VALUES
(5, 4,  1,  89.00, 0, 0, NULL),
(5, 5,  1, 199.00, 0, 0, NULL),
(5, 12, 1, 299.00, 0, 0, NULL);
-- Order 6
INSERT INTO OrderItem (OrderId, ProductId, Count, Price, DiscountFixed, DiscountPercent, Notes) VALUES
(6, 19, 4,  49.00, 0, 0, NULL),
(6, 20, 2, 129.00, 0, 0, NULL);
-- Order 7 (5% kundrabatt på ordernivå)
INSERT INTO OrderItem (OrderId, ProductId, Count, Price, DiscountFixed, DiscountPercent, Notes) VALUES
(7, 16, 2, 349.00, 0, 0, NULL),
(7, 17, 4, 189.00, 0, 0, NULL);
-- Order 8 (100 kr orderrabatt)
INSERT INTO OrderItem (OrderId, ProductId, Count, Price, DiscountFixed, DiscountPercent, Notes) VALUES
(8, 2,  3,  49.00, 0, 0, NULL),
(8, 3,  3,  45.00, 0, 0, NULL),
(8, 11, 2, 149.00, 0, 0, NULL);
-- Order 9
INSERT INTO OrderItem (OrderId, ProductId, Count, Price, DiscountFixed, DiscountPercent, Notes) VALUES
(9, 6,  1, 1299.00, 0, 0, 'Annullerad – lagerfel');
-- Order 10
INSERT INTO OrderItem (OrderId, ProductId, Count, Price, DiscountFixed, DiscountPercent, Notes) VALUES
(10, 7, 1, 1599.00, 0, 0, 'Fellagd order');
-- Order 11
INSERT INTO OrderItem (OrderId, ProductId, Count, Price, DiscountFixed, DiscountPercent, Notes) VALUES
(11, 18,  1, 229.00, 0, 0, 'Lagerslut'),
(11, 13, 10,  49.00, 0, 0, 'Lagerslut');
-- Order 12
INSERT INTO OrderItem (OrderId, ProductId, Count, Price, DiscountFixed, DiscountPercent, Notes) VALUES
(12, 8, 1, 799.00, 0, 0, 'Kund ångrade sig');
-- Order 13
INSERT INTO OrderItem (OrderId, ProductId, Count, Price, DiscountFixed, DiscountPercent, Notes) VALUES
(13, 5, 1, 199.00, 0, 0, 'Reklamation'),
(13, 4, 1,  89.00, 0, 0, 'Reklamation');
-- Order 14
INSERT INTO OrderItem (OrderId, ProductId, Count, Price, DiscountFixed, DiscountPercent, Notes) VALUES
(14, 16, 1, 349.00, 0, 0, 'Felleverat'),
(14, 17, 2, 189.00, 0, 0, 'Felleverat');
-- Order 15
INSERT INTO OrderItem (OrderId, ProductId, Count, Price, DiscountFixed, DiscountPercent, Notes) VALUES
(15, 6, 1, 1299.00, 0, 0, 'Retur – defekt'),
(15, 9, 2,   59.00, 0, 0, NULL);
-- Order 16
INSERT INTO OrderItem (OrderId, ProductId, Count, Price, DiscountFixed, DiscountPercent, Notes) VALUES
(16, 7,  1, 1599.00, 0, 0, 'Defekt vara'),
(16, 10, 1,   79.00, 0, 0, NULL),
(16, 11, 1,  149.00, 0, 0, NULL);

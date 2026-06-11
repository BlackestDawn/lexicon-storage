-- ============================================================
--  Test-data för Storage.API
--  Täcker alla 8 kombinationer av IsPaid/IsDelivered/IsRefunded
--  (minst 2 ordrar per kombination = 16 ordrar totalt)
-- ============================================================

USE LexiconStore;

-- ------------------------------------------------------------
--  Products  (20 st)
-- ------------------------------------------------------------
INSERT INTO Product (Name, Price, Category, Shelf, Count, Description) VALUES
('Hammare 500g',           129.00, 'Verktyg',      'A1',  45,  'Stålhuvud med träskaft'),
('Skruvmejsel Phillips',    49.00, 'Verktyg',      'A1',  80,  'PH2, 150 mm skaft'),
('Skruvmejsel Flathead',    45.00, 'Verktyg',      'A1',  75,  'Flat 6 mm, 150 mm skaft'),
('Måttband 5m',             89.00, 'Mätverktyg',   'A2',  60,  'Automatisk inrullning'),
('Vattenpass 60cm',        199.00, 'Mätverktyg',   'A2',  30,  'Aluminium med 3 bubbelnivåer'),
('Borrmaskin 18V',        1299.00, 'Elverktyg',    'B1',  20,  'Borstlös motor, inkl. 2 batterier'),
('Cirkelsåg 165mm',       1599.00, 'Elverktyg',    'B1',  15,  '5500 rpm, laserguide'),
('Slipmaskin excentr.',    799.00, 'Elverktyg',    'B2',  18,  '125 mm, 12 000 rpm'),
('Skyddsglas klar',         59.00, 'Skyddsutrustning','C1',100, 'EN166 certifierade'),
('Arbetshandskar L',        79.00, 'Skyddsutrustning','C1', 90, 'Skärskyddsnivå C'),
('Hörselskydd SNR30',      149.00, 'Skyddsutrustning','C2', 50, 'Vikbara, SNR 30 dB'),
('Skyddshjälm vit',        299.00, 'Skyddsutrustning','C2', 35, 'EN397, justerhuvud'),
('Spik 50mm 1kg',           49.00, 'Fästelement',  'D1', 200, 'Förzinkad, 1 kg förp.'),
('Skruv 4x40 100-pack',     69.00, 'Fästelement',  'D1', 150, 'Rostfri A2'),
('Bult M8x60 10-pack',      59.00, 'Fästelement',  'D2',  80, 'Inkl. muttrar och brickor'),
('Träskiva 18mm 120x60',   349.00, 'Trävaror',     'E1',  40, 'Björkplywood, slipat'),
('Gipsskiva 13mm 120x60',  189.00, 'Byggmaterial', 'E2',  55, 'Standard, brandskyddad'),
('Plastfilm 4m x 25m',     229.00, 'Byggmaterial', 'F1',  25, 'PE-folie 0,2 mm'),
('Pensel 50mm',              49.00, 'Målning',      'F2', 120, 'Syntetborst, lackpensel'),
('Roller 18cm kit',         129.00, 'Målning',      'F2',  65, 'Inkl. bricka och 2 valsar');

-- ------------------------------------------------------------
--  Order  (16 st – 2 per kombination av IsPaid/IsDelivered/IsRefunded)
-- ------------------------------------------------------------
--  Kombination 1: IsPaid=0 IsDelivered=0 IsRefunded=0  (ej betald, ej levererad, ej återbetald)
INSERT INTO "Order" (CreatedAt, Notes, DiscountFixed, DiscountPercent, IsPaid, PaidAt, IsDelivered, DeliveredAt, IsRefunded, RefundedAt) VALUES
('2025-01-10 09:15:00', 'Inväntar betalning',    0,    0,    0, NULL, 0, NULL, 0, NULL),
('2025-01-18 14:30:00', 'Webb-order, ej betald', 0,    0,    0, NULL, 0, NULL, 0, NULL);

--  Kombination 2: IsPaid=1 IsDelivered=0 IsRefunded=0  (betald, ej levererad)
INSERT INTO "Order" (CreatedAt, Notes, DiscountFixed, DiscountPercent, IsPaid, PaidAt, IsDelivered, DeliveredAt, IsRefunded, RefundedAt) VALUES
('2025-02-03 10:00:00', 'Betald, väntar på lager',     0,    0,    1, '2025-02-03 10:05:00', 0, NULL, 0, NULL),
('2025-02-14 11:20:00', 'Expresslev. beställd',       50,    0,    1, '2025-02-14 11:25:00', 0, NULL, 0, NULL);

--  Kombination 3: IsPaid=0 IsDelivered=1 IsRefunded=0  (levererad men ej betald – t.ex. faktura)
INSERT INTO "Order" (CreatedAt, Notes, DiscountFixed, DiscountPercent, IsPaid, PaidAt, IsDelivered, DeliveredAt, IsRefunded, RefundedAt) VALUES
('2025-03-05 08:00:00', 'Faktura 30 dagar',            0,    0,    0, NULL, 1, '2025-03-07 13:00:00', 0, NULL),
('2025-03-20 09:45:00', 'Levererad, inväntar fakt.',   0,    0,    0, NULL, 1, '2025-03-22 10:00:00', 0, NULL);

--  Kombination 4: IsPaid=1 IsDelivered=1 IsRefunded=0  (klar order)
INSERT INTO "Order" (CreatedAt, Notes, DiscountFixed, DiscountPercent, IsPaid, PaidAt, IsDelivered, DeliveredAt, IsRefunded, RefundedAt) VALUES
('2025-04-01 10:30:00', 'Stamkund, 5% rabatt',         0,    0.05, 1, '2025-04-01 10:35:00', 1, '2025-04-03 14:00:00', 0, NULL),
('2025-04-15 13:00:00', 'Klar order',                100,    0,    1, '2025-04-15 13:02:00', 1, '2025-04-17 09:00:00', 0, NULL);

--  Kombination 5: IsPaid=0 IsDelivered=0 IsRefunded=1  (annullerad innan betalning)
INSERT INTO "Order" (CreatedAt, Notes, DiscountFixed, DiscountPercent, IsPaid, PaidAt, IsDelivered, DeliveredAt, IsRefunded, RefundedAt) VALUES
('2025-05-02 11:00:00', 'Order annullerad av kund',    0,    0,    0, NULL, 0, NULL, 1, '2025-05-02 15:00:00'),
('2025-05-10 09:00:00', 'Fellagd order, återbetald',   0,    0,    0, NULL, 0, NULL, 1, '2025-05-10 09:30:00');

--  Kombination 6: IsPaid=1 IsDelivered=0 IsRefunded=1  (betald, ej levererad, återbetald)
INSERT INTO "Order" (CreatedAt, Notes, DiscountFixed, DiscountPercent, IsPaid, PaidAt, IsDelivered, DeliveredAt, IsRefunded, RefundedAt) VALUES
('2025-06-01 08:30:00', 'Lagerslut – full återbet.',   0,    0,    1, '2025-06-01 08:35:00', 0, NULL, 1, '2025-06-03 10:00:00'),
('2025-06-12 14:00:00', 'Kund ångrade, återbet.',      0,    0,    1, '2025-06-12 14:10:00', 0, NULL, 1, '2025-06-13 09:00:00');

--  Kombination 7: IsPaid=0 IsDelivered=1 IsRefunded=1  (levererad, ej betald, reklamation)
INSERT INTO "Order" (CreatedAt, Notes, DiscountFixed, DiscountPercent, IsPaid, PaidAt, IsDelivered, DeliveredAt, IsRefunded, RefundedAt) VALUES
('2025-07-05 10:00:00', 'Reklamation, faktura makulerad', 0, 0,   0, NULL, 1, '2025-07-07 12:00:00', 1, '2025-07-10 08:00:00'),
('2025-07-20 11:30:00', 'Felleverat, kredit utfärdad',    0, 0,   0, NULL, 1, '2025-07-22 14:00:00', 1, '2025-07-25 09:00:00');

--  Kombination 8: IsPaid=1 IsDelivered=1 IsRefunded=1  (levererad, betald, sedan återbetald)
INSERT INTO "Order" (CreatedAt, Notes, DiscountFixed, DiscountPercent, IsPaid, PaidAt, IsDelivered, DeliveredAt, IsRefunded, RefundedAt) VALUES
('2025-08-03 09:00:00', 'Retur, full återbetalning',   0,    0,    1, '2025-08-03 09:05:00', 1, '2025-08-05 11:00:00', 1, '2025-08-10 13:00:00'),
('2025-08-18 10:15:00', 'Defekt vara, återbet. gjord', 0,    0,    1, '2025-08-18 10:20:00', 1, '2025-08-20 15:00:00', 1, '2025-08-25 10:00:00');

-- ------------------------------------------------------------
--  OrderItem  – kopplar ordrar till produkter
-- ------------------------------------------------------------
-- Order 1
INSERT INTO OrderItem (OrderId, ProductId, Count, Price, DiscountFixed, DiscountPercent, Notes) VALUES
(1, 1,  2, 129.00, 0, 0,    NULL),
(1, 9,  3,  59.00, 0, 0,    NULL);
-- Order 2
INSERT INTO OrderItem (OrderId, ProductId, Count, Price, DiscountFixed, DiscountPercent, Notes) VALUES
(2, 6,  1, 1299.00, 0, 0,   NULL),
(2, 8,  1,  799.00, 0, 0,   NULL);
-- Order 3
INSERT INTO OrderItem (OrderId, ProductId, Count, Price, DiscountFixed, DiscountPercent, Notes) VALUES
(3, 13, 5,  49.00, 0, 0,    NULL),
(3, 14, 3,  69.00, 0, 0,    NULL),
(3, 15, 2,  59.00, 0, 0,    NULL);
-- Order 4 (50 kr orderrabatt)
INSERT INTO OrderItem (OrderId, ProductId, Count, Price, DiscountFixed, DiscountPercent, Notes) VALUES
(4, 7,  1, 1599.00, 0, 0,   NULL),
(4, 10, 2,   79.00, 0, 0,   NULL);
-- Order 5
INSERT INTO OrderItem (OrderId, ProductId, Count, Price, DiscountFixed, DiscountPercent, Notes) VALUES
(5, 4,  1,  89.00, 0, 0,    NULL),
(5, 5,  1, 199.00, 0, 0,    NULL),
(5, 12, 1, 299.00, 0, 0,    NULL);
-- Order 6
INSERT INTO OrderItem (OrderId, ProductId, Count, Price, DiscountFixed, DiscountPercent, Notes) VALUES
(6, 19, 4,  49.00, 0, 0,    NULL),
(6, 20, 2, 129.00, 0, 0,    NULL);
-- Order 7 (5% kundrabatt på ordernivå)
INSERT INTO OrderItem (OrderId, ProductId, Count, Price, DiscountFixed, DiscountPercent, Notes) VALUES
(7, 16, 2, 349.00, 0, 0,    NULL),
(7, 17, 4, 189.00, 0, 0,    NULL);
-- Order 8 (100 kr orderrabatt)
INSERT INTO OrderItem (OrderId, ProductId, Count, Price, DiscountFixed, DiscountPercent, Notes) VALUES
(8, 2,  3,  49.00, 0, 0,    NULL),
(8, 3,  3,  45.00, 0, 0,    NULL),
(8, 11, 2, 149.00, 0, 0,    NULL);
-- Order 9
INSERT INTO OrderItem (OrderId, ProductId, Count, Price, DiscountFixed, DiscountPercent, Notes) VALUES
(9, 6,  1, 1299.00, 0, 0,   'Annullerad – lagerfel');
-- Order 10
INSERT INTO OrderItem (OrderId, ProductId, Count, Price, DiscountFixed, DiscountPercent, Notes) VALUES
(10, 7, 1, 1599.00, 0, 0,   'Fellagd order');
-- Order 11
INSERT INTO OrderItem (OrderId, ProductId, Count, Price, DiscountFixed, DiscountPercent, Notes) VALUES
(11, 18, 1, 229.00, 0, 0,   'Lagerslut'),
(11, 13, 10, 49.00, 0, 0,   'Lagerslut');
-- Order 12
INSERT INTO OrderItem (OrderId, ProductId, Count, Price, DiscountFixed, DiscountPercent, Notes) VALUES
(12, 8,  1, 799.00, 0, 0,   'Kund ångrade sig');
-- Order 13
INSERT INTO OrderItem (OrderId, ProductId, Count, Price, DiscountFixed, DiscountPercent, Notes) VALUES
(13, 5,  1, 199.00, 0, 0,   'Reklamation'),
(13, 4,  1,  89.00, 0, 0,   'Reklamation');
-- Order 14
INSERT INTO OrderItem (OrderId, ProductId, Count, Price, DiscountFixed, DiscountPercent, Notes) VALUES
(14, 16, 1, 349.00, 0, 0,   'Felleverat'),
(14, 17, 2, 189.00, 0, 0,   'Felleverat');
-- Order 15
INSERT INTO OrderItem (OrderId, ProductId, Count, Price, DiscountFixed, DiscountPercent, Notes) VALUES
(15, 6,  1, 1299.00, 0, 0,  'Retur – defekt'),
(15, 9,  2,   59.00, 0, 0,  NULL);
-- Order 16
INSERT INTO OrderItem (OrderId, ProductId, Count, Price, DiscountFixed, DiscountPercent, Notes) VALUES
(16, 7,  1, 1599.00, 0, 0,  'Defekt vara'),
(16, 10, 1,   79.00, 0, 0,  NULL),
(16, 11, 1,  149.00, 0, 0,  NULL);

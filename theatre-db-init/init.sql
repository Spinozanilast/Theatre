INSERT INTO public."Halls" ("SeatsNumber", "HallName")
VALUES (600, 'Победа'),
       (300, 'Искра'),
       (150, 'Жизнь'),
       (50, 'Мечта');

-- TRUNCATE TABLE public."Halls" RESTART IDENTITY CASCADE;

INSERT INTO public."Sectors" ("HallId", "RowsCount", "SeatsNum")
VALUES
    -- Зал "Победа" (600 мест)
    (1, 10, 100), -- Сектор 1 (10 рядов, всего 100 мест)
    (1, 10, 100), -- Сектор 2 (10 рядов, всего 100 мест)
    (1, 10, 100), -- Сектор 3 (10 рядов, всего 100 мест)
    (1, 10, 100), -- Сектор 4 (10 рядов, всего 100 мест)
    (1, 10, 100), -- Сектор 5 (10 рядов, всего 100 мест)
    (1, 10, 100), -- Сектор 6 (10 рядов, всего 100 мест)

-- Зал "Искра" (300 мест)
    (2, 5, 150),  -- Сектор 1 (5 рядов, всего 150 мест)
    (2, 5, 150),  -- Сектор 2 (5 рядов, всего 150 мест)

-- Зал "Жизнь" (150 мест)
    (3, 3, 75),   -- Сектор 1 (3 ряда, всего 75 мест)
    (3, 3, 75),   -- Сектор 2 (3 ряда, всего 75 мест)

-- Зал "Мечта" (50 мест)
    (4, 5, 50); -- Сектор 1 (1 ряд, всего 50 мест)

-- TRUNCATE TABLE public."Sectors" RESTART IDENTITY CASCADE;

INSERT INTO public."Rows" ("HallId", "SectorId", "SeatsNumber")
VALUES
    -- Зал "Победа" (600 мест)
    (1, 1, 10), -- Ряд 1 в секторе 1 (10 мест)
    (1, 1, 10), -- Ряд 2 в секторе 1 (10 мест)
    (1, 1, 10), -- Ряд 3 в секторе 1 (10 мест)
    (1, 1, 10), -- Ряд 4 в секторе 1 (10 мест)
    (1, 1, 10), -- Ряд 5 в секторе 1 (10 мест)
    (1, 1, 10), -- Ряд 6 в секторе 1 (10 мест)
    (1, 1, 10), -- Ряд 7 в секторе 1 (10 мест)
    (1, 1, 10), -- Ряд 8 в секторе 1 (10 мест)
    (1, 1, 10), -- Ряд 9 в секторе 1 (10 мест)
    (1, 1, 10), -- Ряд 10 в секторе 1 (10 мест)

    (1, 2, 10), -- Ряд 1 в секторе 2 (10 мест)
    (1, 2, 10), -- Ряд 2 в секторе 2 (10 мест)
    (1, 2, 10), -- Ряд 3 в секторе 2 (10 мест)
    (1, 2, 10), -- Ряд 4 в секторе 2 (10 мест)
    (1, 2, 10), -- Ряд 5 в секторе 2 (10 мест)
    (1, 2, 10), -- Ряд 6 в секторе 2 (10 мест)
    (1, 2, 10), -- Ряд 7 в секторе 2 (10 мест)
    (1, 2, 10), -- Ряд 8 в секторе 2 (10 мест)
    (1, 2, 10), -- Ряд 9 в секторе 2 (10 мест)
    (1, 2, 10), -- Ряд 10 в секторе 2 (10 мест)

    (1, 3, 10), -- Ряд 1 в секторе 3 (10 мест)
    (1, 3, 10), -- Ряд 2 в секторе 3 (10 мест)
    (1, 3, 10), -- Ряд 3 в секторе 3 (10 мест)
    (1, 3, 10), -- Ряд 4 в секторе 3 (10 мест)
    (1, 3, 10), -- Ряд 5 в секторе 3 (10 мест)
    (1, 3, 10), -- Ряд 6 в секторе 3 (10 мест)
    (1, 3, 10), -- Ряд 7 в секторе 3 (10 мест)
    (1, 3, 10), -- Ряд 8 в секторе 3 (10 мест)
    (1, 3, 10), -- Ряд 9 в секторе 3 (10 мест)
    (1, 3, 10), -- Ряд 10 в секторе 3 (10 мест)

    (1, 4, 10), -- Ряд 1 в секторе 4 (10 мест)
    (1, 4, 10), -- Ряд 2 в секторе 4 (10 мест)
    (1, 4, 10), -- Ряд 3 в секторе 4 (10 мест)
    (1, 4, 10), -- Ряд 4 в секторе 4 (10 мест)
    (1, 4, 10), -- Ряд 5 в секторе 4 (10 мест)
    (1, 4, 10), -- Ряд 6 в секторе 4 (10 мест)
    (1, 4, 10), -- Ряд 7 в секторе 4 (10 мест)
    (1, 4, 10), -- Ряд 8 в секторе 4 (10 мест)
    (1, 4, 10), -- Ряд 9 в секторе 4 (10 мест)
    (1, 4, 10), -- Ряд 10 в секторе 4 (10 мест)

    (1, 5, 10), -- Ряд 1 в секторе 5 (10 мест)
    (1, 5, 10), -- Ряд 2 в секторе 5 (10 мест)
    (1, 5, 10), -- Ряд 3 в секторе 5 (10 мест)
    (1, 5, 10), -- Ряд 4 в секторе 5 (10 мест)
    (1, 5, 10), -- Ряд 5 в секторе 5 (10 мест)
    (1, 5, 10), -- Ряд 6 в секторе 5 (10 мест)
    (1, 5, 10), -- Ряд 7 в секторе 5 (10 мест)
    (1, 5, 10), -- Ряд 8 в секторе 5 (10 мест)
    (1, 5, 10), -- Ряд 9 в секторе 5 (10 мест)
    (1, 5, 10), -- Ряд 10 в секторе 5 (10 мест)

    (1, 6, 10), -- Ряд 1 в секторе 6 (10 мест)
    (1, 6, 10), -- Ряд 2 в секторе 6 (10 мест)
    (1, 6, 10), -- Ряд 3 в секторе 6 (10 мест)
    (1, 6, 10), -- Ряд 4 в секторе 6 (10 мест)
    (1, 6, 10), -- Ряд 5 в секторе 6 (10 мест)
    (1, 6, 10), -- Ряд 6 в секторе 6 (10 мест)
    (1, 6, 10), -- Ряд 7 в секторе 6 (10 мест)
    (1, 6, 10), -- Ряд 8 в секторе 6 (10 мест)
    (1, 6, 10), -- Ряд 9 в секторе 6 (10 мест)
    (1, 6, 10), -- Ряд 10 в секторе 6 (10 мест)

-- Зал "Искра" (300 мест)
    (2, 1, 30), -- Ряд 1 в секторе 1 (30 мест)
    (2, 1, 30), -- Ряд 2 в секторе 1 (30 мест)
    (2, 1, 30), -- Ряд 3 в секторе 1 (30 мест)
    (2, 1, 30), -- Ряд 4 в секторе 1 (30 мест)
    (2, 1, 30), -- Ряд 5 в секторе 1 (30 мест)

    (2, 2, 30), -- Ряд 1 в секторе 2 (30 мест)
    (2, 2, 30), -- Ряд 2 в секторе 2 (30 мест)
    (2, 2, 30), -- Ряд 3 в секторе 2 (30 мест)
    (2, 2, 30), -- Ряд 4 в секторе 2 (30 мест)
    (2, 2, 30), -- Ряд 5 в секторе 2 (30 мест)

-- Зал "Жизнь" (150 мест)
    (3, 1, 25), -- Ряд 1 в секторе 1 (25 мест)
    (3, 1, 25), -- Ряд 2 в секторе 1 (25 мест)
    (3, 1, 25), -- Ряд 3 в секторе 1 (25 мест)

    (3, 2, 25), -- Ряд 1 в секторе 2 (25 мест)
    (3, 2, 25), -- Ряд 2 в секторе 2 (25 мест)
    (3, 2, 25), -- Ряд 3 в секторе 2 (25 мест)

-- Зал "Мечта" (50 мест)
    (4, 1, 10), -- Ряд 1 в секторе 1 (10 мест)
    (4, 1, 10), -- Ряд 2 в секторе 1 (10 мест)
    (4, 1, 10), -- Ряд 3 в секторе 1 (10 мест)
    (4, 1, 10), -- Ряд 4 в секторе 1 (10 мест)
    (4, 1, 10); -- Ряд 5 в секторе 1 (10 мест)


INSERT INTO public."Seats" ("HallId", "SectorId", "RowNumber", "SeatNumber", "SeatType", "RowId", "IsOccupied")
SELECT
    r."HallId",
    r."SectorId",
    r."Id" AS "RowNumber",
    s."SeatNumber",
    'Standard' AS "SeatType",
    r."Id" AS "RowId",
    false
FROM
    public."Rows" r
        CROSS JOIN
    generate_series(1, r."SeatsNumber") s("SeatNumber")
ORDER BY
    r."HallId", r."SectorId", r."Id", s."SeatNumber";

INSERT INTO public."Events" ("Id", "Name", "ImageUrls", "Description", "DateTime", "EventType", "HallId", "Price", "EventState")
VALUES
    ('6ba7b81e-9dad-11d1-80b4-00c04fd430c8', 'Giselle', ARRAY['https://i.pinimg.com/564x/43/c4/7d/43c47d3e09b68d43ca15b7b1a632dbeb.jpg'], 'A classic ballet performance by Adolphe Adam, choreographed by Jean Coralli and Jules Perrot, and starring the American Ballet Theatre.', '2024-11-13 19:00:00', 'Ballet', 1, 50.0, TRUE),
    ('6ba7b81f-9dad-11d1-80b4-00c04fd430c8', 'The Merry Widow', ARRAY['https://i.pinimg.com/736x/0c/34/0c/0c340c072723e09cc6709de802897d49.jpg'], 'An opera performance by Franz Lehár, directed by Susan Stroman and starring Renée Fleming, Nathan Gunn, and Kelli O''Hara.', '2024-11-14 19:00:00', 'Opera', 3, 45.0, TRUE),
    ('6ba7b820-9dad-11d1-80b4-00c04fd430c8', 'The Firebird', ARRAY['https://i.pinimg.com/736x/ab/fe/28/abfe282dd2bdf3b8c49c6ce19c087483.jpg'], 'A ballet performance by Igor Stravinsky, choreographed by Michel Fokine and starring the Mariinsky Ballet.', '2024-11-15 19:00:00', 'Ballet', 1, 50.0, TRUE),
    ('6ba7b821-9dad-11d1-80b4-00c04fd430c8', 'The Marriage of Figaro', ARRAY['https://i.pinimg.com/564x/37/c1/f9/37c1f91bb751c90b44e069e0265811bd.jpg'], 'An opera performance by Wolfgang Amadeus Mozart, directed by Richard Eyre and starring Ildar Abdrazakov, Marlis Petersen, and Peter Mattei.', '2024-11-16 19:00:00', 'Opera', 3, 55.0, TRUE),
    ('6ba7b822-9dad-11d1-80b4-00c04fd430c8', 'Rigoletto', ARRAY['https://i.pinimg.com/564x/97/5b/0a/975b0a24335e5298a7f64d6ae3667324.jpg'], 'An opera performance by Giuseppe Verdi, directed by Michael Mayer and starring Željko Lučić, Diana Damrau, and Piotr Beczała.', '2024-11-17 19:00:00', 'Opera', 3, 60.0, TRUE);

INSERT INTO public."EventCasts" ("EventId", "Directors", "ScreenWriters", "Actors")
VALUES
    ('6ba7b81e-9dad-11d1-80b4-00c04fd430c8', ARRAY['Jean Coralli', 'Jules Perrot'], ARRAY['Adolphe Adam'], ARRAY['American Ballet Theatre']),
    ('6ba7b81f-9dad-11d1-80b4-00c04fd430c8', ARRAY['Susan Stroman'], ARRAY['Franz Lehár'], ARRAY['Renée Fleming', 'Nathan Gunn', 'Kelli O''Hara']),
    ('6ba7b820-9dad-11d1-80b4-00c04fd430c8', ARRAY['Michel Fokine'], ARRAY['Igor Stravinsky'], ARRAY['Mariinsky Ballet']),
    ('6ba7b821-9dad-11d1-80b4-00c04fd430c8', ARRAY['Richard Eyre'], ARRAY['Wolfgang Amadeus Mozart'], ARRAY['Ildar Abdrazakov', 'Marlis Petersen', 'Peter Mattei']),
    ('6ba7b822-9dad-11d1-80b4-00c04fd430c8', ARRAY['Michael Mayer'], ARRAY['Giuseppe Verdi'], ARRAY['Željko Lučić', 'Diana Damrau', 'Piotr Beczała']);

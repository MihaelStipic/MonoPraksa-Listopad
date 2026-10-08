DROP TABLE IF EXISTS post;
DROP TABLE IF EXISTS author;
DROP TABLE IF EXISTS category;

CREATE TABLE author (
    id         uuid PRIMARY KEY DEFAULT gen_random_uuid(),
    first_name varchar(50) NOT NULL,
    last_name  varchar(50) NOT NULL,
    email      varchar(255) UNIQUE
);

CREATE TABLE category (
    id   uuid PRIMARY KEY DEFAULT gen_random_uuid(),
    name varchar(50) NOT NULL UNIQUE
);

CREATE TABLE post (
    id          uuid PRIMARY KEY DEFAULT gen_random_uuid(),
    author_id   uuid NOT NULL REFERENCES author(id),
    category_id uuid NOT NULL REFERENCES category(id),
    title       varchar(200) NOT NULL,
    post_text   text NOT NULL,
    created_at  timestamptz NOT NULL DEFAULT now()
);

INSERT INTO author (first_name, last_name, email) VALUES
('Ivan', 'Horvat', 'ivan.horvat@example.com'),
('Ana', 'Kovač', 'ana.kovac@example.com'),
('Marko', 'Babić', 'marko.babic@example.com'),
('Petra', 'Jurić', 'petra.juric@example.com'),
('Luka', 'Novak', 'luka.novak@example.com'),
('Maja', 'Matić', 'maja.matic@example.com'),
('Tomislav', 'Knežević', 'tomislav.knezevic@example.com'),
('Ivana', 'Vidović', 'ivana.vidovic@example.com'),
('Josip', 'Perić', 'josip.peric@example.com'),
('Marta', 'Tomić', 'marta.tomic@example.com');

INSERT INTO category (name) VALUES
('Tech'), ('Putovanja'), ('Hrana'), ('Sport'), ('Glazba'), ('Znanost');

INSERT INTO post (author_id, category_id, title, post_text) VALUES
((SELECT id FROM author WHERE email = 'ivan.horvat@example.com'), (SELECT id FROM category WHERE name = 'Tech'), 'Prvi post o Postgresu', 'Naučio sam što je FK i zašto je bitan.'),
((SELECT id FROM author WHERE email = 'ivan.horvat@example.com'), (SELECT id FROM category WHERE name = 'Tech'), 'Zašto mrzim CSS', 'Dugi rant o CSS-u.'),
((SELECT id FROM author WHERE email = 'ivan.horvat@example.com'), (SELECT id FROM category WHERE name = 'Znanost'), 'Što je Turingov stroj', 'Traka, glava i stanja.'),

((SELECT id FROM author WHERE email = 'ana.kovac@example.com'), (SELECT id FROM category WHERE name = 'Putovanja'), 'Tjedan u Toulouseu', 'Tekst o putovanju.'),
((SELECT id FROM author WHERE email = 'ana.kovac@example.com'), (SELECT id FROM category WHERE name = 'Putovanja'), 'Vikend u Splitu', 'Sunce, more, gužva.'),
((SELECT id FROM author WHERE email = 'ana.kovac@example.com'), (SELECT id FROM category WHERE name = 'Hrana'), 'Najbolji čevapi u Slavoniji', 'Tekst o čevapima.'),

((SELECT id FROM author WHERE email = 'marko.babic@example.com'), (SELECT id FROM category WHERE name = 'Sport'), 'Zašto je NK Osijek opet izgubio', 'Bolna analiza.'),
((SELECT id FROM author WHERE email = 'marko.babic@example.com'), (SELECT id FROM category WHERE name = 'Sport'), 'Trčanje uz Dravu', 'Rute i savjeti.'),
((SELECT id FROM author WHERE email = 'marko.babic@example.com'), (SELECT id FROM category WHERE name = 'Tech'), 'C++ pointeri za ljude', 'Bez filozofije.'),

((SELECT id FROM author WHERE email = 'petra.juric@example.com'), (SELECT id FROM category WHERE name = 'Glazba'), 'Top 10 albuma godine', 'Subjektivna lista.'),
((SELECT id FROM author WHERE email = 'petra.juric@example.com'), (SELECT id FROM category WHERE name = 'Glazba'), 'Gitara od nule', 'Prvi akordi.'),
((SELECT id FROM author WHERE email = 'petra.juric@example.com'), (SELECT id FROM category WHERE name = 'Hrana'), 'Fiš paprikaš korak po korak', 'Recept.'),

((SELECT id FROM author WHERE email = 'luka.novak@example.com'), (SELECT id FROM category WHERE name = 'Tech'), 'Docker bez boli', 'Image, container, volume.'),
((SELECT id FROM author WHERE email = 'luka.novak@example.com'), (SELECT id FROM category WHERE name = 'Tech'), 'Zašto indeksi ubrzavaju upite', 'B-stablo ukratko.'),
((SELECT id FROM author WHERE email = 'luka.novak@example.com'), (SELECT id FROM category WHERE name = 'Znanost'), 'Crne rupe objašnjene', 'Bez matematike.'),

((SELECT id FROM author WHERE email = 'maja.matic@example.com'), (SELECT id FROM category WHERE name = 'Putovanja'), 'Plitvice izvan sezone', 'Manje ljudi, više mira.'),
((SELECT id FROM author WHERE email = 'maja.matic@example.com'), (SELECT id FROM category WHERE name = 'Hrana'), 'Kulen: mit ili istina', 'Što se zapravo jede.'),
((SELECT id FROM author WHERE email = 'maja.matic@example.com'), (SELECT id FROM category WHERE name = 'Sport'), 'Planinarenje na Papuk', 'Staze i oprema.'),

((SELECT id FROM author WHERE email = 'tomislav.knezevic@example.com'), (SELECT id FROM category WHERE name = 'Tech'), 'Git rebase vs merge', 'Kad što koristiti.'),
((SELECT id FROM author WHERE email = 'tomislav.knezevic@example.com'), (SELECT id FROM category WHERE name = 'Znanost'), 'Kako radi GPS', 'Sateliti i relativnost.'),
((SELECT id FROM author WHERE email = 'tomislav.knezevic@example.com'), (SELECT id FROM category WHERE name = 'Glazba'), 'Vinil se vratio', 'Zašto ljudi opet slušaju ploče.'),

((SELECT id FROM author WHERE email = 'ivana.vidovic@example.com'), (SELECT id FROM category WHERE name = 'Hrana'), 'Palačinke za početnike', 'Tri sastojka.'),
((SELECT id FROM author WHERE email = 'ivana.vidovic@example.com'), (SELECT id FROM category WHERE name = 'Putovanja'), 'Interrail s rancem', 'Budžet i ruta.'),
((SELECT id FROM author WHERE email = 'ivana.vidovic@example.com'), (SELECT id FROM category WHERE name = 'Sport'), 'Košarka u Osijeku', 'Gdje igrati.'),

((SELECT id FROM author WHERE email = 'josip.peric@example.com'), (SELECT id FROM category WHERE name = 'Tech'), 'REST vs GraphQL', 'Ovisi o projektu.'),
((SELECT id FROM author WHERE email = 'josip.peric@example.com'), (SELECT id FROM category WHERE name = 'Znanost'), 'Astrofotografija s Arduinom', 'Tracker za zvjezdano nebo.'),
((SELECT id FROM author WHERE email = 'josip.peric@example.com'), (SELECT id FROM category WHERE name = 'Glazba'), 'Sintisajzeri za početnike', 'Oscilator, filter, envelope.'),

((SELECT id FROM author WHERE email = 'marta.tomic@example.com'), (SELECT id FROM category WHERE name = 'Hrana'), 'Domaći kruh bez mjesila', 'Treba samo vremena.'),
((SELECT id FROM author WHERE email = 'marta.tomic@example.com'), (SELECT id FROM category WHERE name = 'Putovanja'), 'Dan u Zagrebu', 'Što vidjeti.'),
((SELECT id FROM author WHERE email = 'marta.tomic@example.com'), (SELECT id FROM category WHERE name = 'Tech'), 'SQL JOIN-ovi na primjerima', 'INNER, LEFT, i kad koji.');


---===================================-UPITI-===================================---
--SELECT--
SELECT 
	a.id,
    a.first_name, 
    a.last_name, 
    p.title, 
    p.post_text 
FROM post p 
INNER JOIN author a ON a.id = p.author_id;


select first_name, last_name, title, post_text from post p inner join author a on a.id = p.author_id

select a.first_name, a.last_name
from post p inner join author a on a.Id=p.author_id
group by a.Id

--ALTER TABLE--

ALTER TABLE post
ADD COLUMN is_published boolean DEFAULT true;

--LEFT JOIN vs RIGHT JOIN--

SELECT *
FROM post p
LEFT JOIN author a ON a.id = p.author_id;

SELECT *
FROM post p
right JOIN author a ON a.id = p.author_id;

--INSERT--

INSERT INTO author (first_name, last_name, email) VALUES ('Nema', 'Postova', 'nema@example.com');
INSERT INTO category (name) VALUES ('Prazna kategorija');

--COUNT()--
SELECT a.first_name,a.last_name, COUNT(p.Id)
FROM author a
LEFT JOIN post p ON p.author_id = a.Id
GROUP BY a.Id;

--UPDATE--

UPDATE post
SET title = 'Novi naslov'
WHERE Id= (SELECT author_id FROM POST LIMIT 1);

--INDEX--
CREATE INDEX idx_post_author_id ON post(author_id);
CREATE INDEX idx_post_category_id ON post(category_id);

EXPLAIN ANALYZE SELECT * FROM post WHERE author_id = (SELECT author_id FROM POST LIMIT 1);
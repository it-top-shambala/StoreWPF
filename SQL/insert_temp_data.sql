INSERT INTO host1323541_store.tab_products (name, annotation, image)
VALUES ('Чай', 'Самый вкусный чай', ' ');

INSERT INTO host1323541_store.tab_products (name, annotation, image)
VALUES ('Кофе', 'Самый крепкий кофе', ' ');

INSERT INTO host1323541_store.tab_product_amounts (product_id, amount)
VALUES (1, 10);

INSERT INTO host1323541_store.tab_product_amounts (product_id, amount)
VALUES (2, 10);

INSERT INTO host1323541_store.tab_product_prices (product_id, price)
VALUES (1, 150);

INSERT INTO host1323541_store.tab_product_prices (product_id, price)
VALUES (2, 3000);

INSERT INTO host1323541_store.tab_role_types (name)
VALUES ('customer');

INSERT INTO host1323541_store.tab_role_types (name)
VALUES ('admin');

INSERT INTO host1323541_store.tab_accounts (login, password, is_active)
VALUES ('user', '123', DEFAULT);

INSERT INTO host1323541_store.tab_accounts (login, password, is_active)
VALUES ('admin', 'admin', DEFAULT);

INSERT INTO host1323541_store.tab_accounts (login, password, is_active)
VALUES ('anonim', '123', 0);

INSERT INTO host1323541_store.tab_roles (account_id, role_type_id)
VALUES (1, 1);

INSERT INTO host1323541_store.tab_roles (account_id, role_type_id)
VALUES (2, 2);

INSERT INTO host1323541_store.tab_roles (account_id, role_type_id)
VALUES (3, 2);

INSERT INTO host1323541_store.tab_users (first_name, last_name, email, phone)
VALUES ('Andrey', 'Starinin', 'starininandrey@gmail.com', '+79042144491');

INSERT INTO host1323541_store.tab_users (first_name, last_name, email, phone)
VALUES ('Admin', 'Administrator', 'admin@store.ru', '+71231231212');

INSERT INTO host1323541_store.tab_users (first_name, last_name, email, phone)
VALUES ('Anonim', 'Anonimus', 'anonim@store.ru', '+71231234567');

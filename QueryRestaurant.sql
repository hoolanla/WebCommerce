select tb_Order_Header.order_no,table_name,order_detail_food_id,order_detail_food_name,order_detail_food_price
,order_detail_food_size,order_detail_food_taste,tb_Food_Status.food_status,tb_Order_Detail.order_detail_id,menu_picture
from tb_Order_Header inner join tb_Order_Detail on tb_Order_Header.order_no = tb_Order_Detail.order_no 
inner join tb_Table on tb_Table.table_id = tb_Order_Header.table_id
inner join tb_Order_Status on tb_Order_Header.order_status = tb_Order_Status.keys
inner join tb_Food_Status on tb_Order_Detail.order_detail_food_status = tb_Food_Status.keys
inner join tb_Menu on tb_Menu.menu_id = order_detail_food_id
where tb_Order_Header.restaurant_id = '1' and tb_Order_Header.created_date between '09/25/2019 00:00' and '09/25/2019 23:59' 
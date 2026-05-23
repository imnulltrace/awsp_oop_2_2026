# Aplikacja do zamawiania pizzy
 
class Topping:
    def __init__(self, name, extra_cost):
        self.name = name
        self.extra_cost = extra_cost


class Pizza:
    def __init__(self, size, base_price):
        self.size = size
        self.base_price = base_price
        self.toppings = []

    def add_topping(self, topping):
        self.toppings.append(topping)

    def get_price(self):
        total = self.base_price
        for t in self.toppings:
            total += t.extra_cost
        return total

    def describe(self):
        names = [t.name for t in self.toppings]
        tops = ", ".join(names) if names else "brak dodatków"
        return f"Pizza {self.size} ({tops}) – {self.get_price():.2f} zł"


class Order:
    def __init__(self, customer_name):
        self.customer_name = customer_name
        self.pizzas = []

    def add_item(self, pizza):
        self.pizzas.append(pizza)

    def calculate_total(self):
        return sum(p.get_price() for p in self.pizzas)

    def print_summary(self):
        print(f"===== Zamówienie: {self.customer_name} =====")
        for p in self.pizzas:
            print(f"  {p.describe()}")
        print(f"Razem: {self.calculate_total():.2f} zł")

# Testy

if __name__ == "__main__":
    cheese = Topping("Mozzarella", 2.0)
    pepperoni = Topping("Pepperoni", 3.5)
    mushrooms = Topping("Pieczarki", 1.5)

    pizza1 = Pizza("duża", 25.0)
    pizza1.add_topping(cheese)
    pizza1.add_topping(pepperoni)

    pizza2 = Pizza("średnia", 20.0)
    pizza2.add_topping(cheese)
    pizza2.add_topping(mushrooms)

    order = Order("Jan Kowalski")
    order.add_item(pizza1)
    order.add_item(pizza2)
    order.print_summary()
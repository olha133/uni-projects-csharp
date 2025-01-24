# Store Simulation System

This project implements a **Store Simulation System** using object-oriented programming principles in C#. It simulates buyers interacting with stores to purchase products based on their budgets, preferences, and discount cards.

## Features

### Buyers
There are three types of buyers, each with different purchasing behaviors:
1. **CheapBuyer**: Looks for the lowest price across all available stores before making a purchase.
2. **EagerBuyer**: Buys their desired products as soon as they find them in any store.
3. **LazyBuyer**: Visits only a limited number of stores to purchase their desired products.

### Stores
Stores manage inventory, apply discounts, and sell products to buyers:
- **Product Management**: Stock products, apply category-specific discounts, and track inventory levels.
- **Price Calculation**: Adjust product prices based on discounts and income rates.
- **Sales**: Sell products to buyers if they meet the buyer’s budget and wish list requirements.

### Product Management
Products are categorized into types, and each product includes:
- Name
- Price
- Category (e.g., electronics, drinks)

### Discount Cards
Buyers can use discount cards that:
- Apply discounts for specific product categories.
- Validate discounts for eligible purchases.

## Classes Overview

### 1. `Buyer` (Abstract)
Represents a generic buyer with properties:
- **Budget**: Available money for purchases.
- **Wish List**: A list of products they want to buy.
- **Has Bought**: Tracks products they have purchased.

### 2. `CheapBuyer`, `EagerBuyer`, `LazyBuyer` (Derived Classes)
Implement specific purchasing strategies.

### 3. `Store`
Manages products and facilitates transactions:
- Stocks products and applies discounts.
- Calculates prices for buyers with or without discount cards.
- Tracks store income from sales.

### 4. `Product`
Represents items available for purchase:
- Name
- Price
- Product Type (e.g., electronics, drinks)

### 5. `Card`
Represents discount cards that provide:
- Specific category discounts.
- Validation for applicable categories.

### 6. `Wish`
Tracks a buyer’s desired products and quantities.

---

## How It Works

1. **Initialize Buyers and Stores**:
   - Create buyers with budgets and wish lists.
   - Populate stores with products, inventory, and discounts.

2. **Buyer Visits Stores**:
   - Each buyer type interacts with stores according to their behavior:
     - **CheapBuyer**: Finds the cheapest price.
     - **EagerBuyer**: Buys immediately.
     - **LazyBuyer**: Visits only a few stores.

3. **Product Transactions**:
   - Buyers purchase products if they can afford them and the store has sufficient inventory.

4. **Track Results**:
   - Monitor buyer purchases, store income, and remaining inventory.

﻿namespace AdoNetCrudProducts.Exceptions;

public class ProductNotFoundException(int productId) : Exception($"Product with ID {productId} not found.") { }

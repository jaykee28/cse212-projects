


Console.WriteLine("\n======================\nCustomer Service\n======================");
CustomerService.Run();
// CustomerServiceSolution.Run();

Console.WriteLine("Test Max Size:");

var serviceValid = new CustomerService(4);
Console.WriteLine(serviceValid); // should show max_size=4

var serviceInvalid = new CustomerService(0);
Console.WriteLine(serviceInvalid); // should show max_size=10

Console.WriteLine("=================");

  // Test 1: Add 1 customer and serve
        var service = new CustomerService(4);
        Console.WriteLine("Test 1: Add 1 customer and serve");
        service.AddNewCustomer("Alice", "A01", "Login issue");
        service.ServeCustomer();
        Console.WriteLine("=================");

        // Test 2: Add 2 customers and serve both
        Console.WriteLine("Test 2: Add 2 customers and serve both");
        service = new CustomerService(4);
        service.AddNewCustomer("Bob", "B02", "Password reset");
        service.AddNewCustomer("Carol", "C03", "Payment issue");
        Console.WriteLine($"Before serving: {service}");
        service.ServeCustomer();
        service.ServeCustomer();
        Console.WriteLine($"After serving: {service}");
        Console.WriteLine("=================");

        // Test 3: Serve from empty queue
        Console.WriteLine("Test 3: Serve from empty queue");
        service = new CustomerService(4);
        service.ServeCustomer();
        Console.WriteLine("=================");

        // Test 4: Add more customers than max
        Console.WriteLine("Test 4: Add more customers than max");
        service = new CustomerService(4);
        service.AddNewCustomer("David", "D04", "Refund");
        service.AddNewCustomer("Eve", "E05", "Technical issue");
        service.AddNewCustomer("Frank", "F06", "Account locked");
        service.AddNewCustomer("Grace", "G07", "Billing query");
        service.AddNewCustomer("Hank", "H08", "Cannot login"); // Should trigger error
        Console.WriteLine($"Queue after adding: {service}");
        Console.WriteLine("=================");

        // Test 5: Invalid max size defaults to 10
        Console.WriteLine("Test 5: Invalid max size defaults to 10");
        service = new CustomerService(0);
        service.AddNewCustomer("Ivy", "I09", "Password issue");
        Console.WriteLine($"Queue max size should be 10: {service}");
        Console.WriteLine("=================");
    


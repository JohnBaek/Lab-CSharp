HttpClient client = new HttpClient();


var response = await client.PostAsync("http://localhost:8082/api/v1/my-working-status/private/to-step-out", new StringContent("eba5db8e-f109-41c5-80cb-149efcbd0fe1", System.Text.Encoding.UTF8, "text/plain"));

// Ensure the response was successful
response.EnsureSuccessStatusCode();

// Read the response content as a string
string responseBody = await response.Content.ReadAsStringAsync();

// Process the response as needed
Console.WriteLine("Response: " + responseBody);
Console.ReadKey();


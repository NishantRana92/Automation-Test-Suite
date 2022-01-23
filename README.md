# Automated-test-suite

- This automation suite has been completed with the use of dotnet framework with selenium webdriver and c#.

- To build the project please use command 
> dotnet build
- To run all tests please use command 
> dotnet test 

# Browser used 

> Chrome version Version 97.0.4692.99 


**When new version is pushed the maintenance of the test suite would be needed to update any XPath changed.**



# Question Answers from Planit Technical Assessment – Automation


## (Question) What other possible scenario’s would you suggest for testing the Jupiter Toys application? 

 
- we can add sceario where user delete the items in the cart and validate the cart Items, updated sum of each item and Updated total sum 
- We can add scenario to empty the cart and validate the cart Items.
- we can add scenario for validating and submiting the delivery details and payment details 

## (Question) Jupiter Toys is expected to grow and expand its offering into books, tech, and modern art. We are expecting the of tests will grow to a very large number.
### 1. What approaches could you used to reduce overall execution time?
### 2. How will your framework cater for this?

There are few things which we can do to reduce the overall execution time using selenium test automation with Nunit
-	By Implementing explicit time then Time. Sleep or Thread. Sleep as by introducing explicit time, it will not stop the execution of the script for the time specified in the script, irrespective of the fact that the element on the web page has been found. (Example of this has been implemented in this test framework)
-	Also by using selenium waits, we are less likely to have flaky test
-	By using Nunit, we can introduce  [Parallelizable] to our test suite by doing that, if our application expands into other category’s we can run them in parallel which will reduce the time significantly. (Example of this has been implemented in this test framework)

## (Question) Describe when to use a BDD approach to automation and when NOT to use BDD 

**When to use**

- When working in rapid, small iterations of development cycle we can use BDD as it can increase the feedback
- We can also use BDD approach where collaboration across the roles are encouraged so that tests can be written in English formatted scenarios so anyone can understand the test cases and see the requirement coverage.

**When not to use BDD**

- BDD requires the involvement from teams and stakeholders within the organization, if management is not able to understand the concept of BDD and or are still exploring or discovering the product, in that case, we should avoid using the BDD approach.





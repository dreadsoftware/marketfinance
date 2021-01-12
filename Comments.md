 ## Issues with `ProductApplicationService`.

 1. It is not possible to add a new product without modifying core service.
 2. Service contains product specific business logic (creating dto objects).
 3. Each product's services are instantiated before use.
 4. Direct access to external services makes it impossible to create a unified interface.
 5. DRY Duplicated code for creating CompanyDataRequest object.
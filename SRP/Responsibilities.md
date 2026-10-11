# SRP Responsibilities Analysis

## 1. WardBoard

### Responsibilities

- Bed and patient tracking
- Acuity scoring
- Pager alerting and logging
- Handoff note formatting
- Census CSV export

### Why this violates SRP

it violates the srp cuz if we want to change how to make csv what that got to do with tracking patient also same for pager alerting thats not related to it

## 2. AppointmentDesk

### Responsibilities

- Appointment scheduling and booking
- Calendar file generation (ICS)
- SMS reminder text generation

### Why this violates SRP

it violates it since this class is for booking appointment its not related to sending sms or generate files for calender

## 3. CheckoutBasket

### Responsibilities

- Basket management
- Price and discount calculation
- Coupon text parsing
- Gift message generation
- Payment authorization code generation

### Why this violates SRP

it violates it since this class is for basket mangemtn and gifts message isnt related to it or coupon handling

## 4. CourseEnrollmentDesk

### Responsibilities

- Student enrollment and seat management
- Waitlist management and promotion
- Welcome packet generation
- Tuition invoice generation and VAT calculation

### Why this violates SRP

It violates SRP because enrollment, welcome messages, and invoices are different responsibilities.

## 5. GradeBook

### Responsibilities

- Recording and storing student scores
- Calculating average scores
- Assigning letter grades
- Checking honor roll eligibility
- Generating transcripts
- Exporting grades to CSV

### Why this violates SRP

It violates SRP because grading, academic rules, and transcript generation are different responsibilities.

## 6. KitchenTicket

### Responsibilities

- Managing order items and ingredients
- Detecting allergens
- Estimating food preparation time
- Rendering thermal kitchen tickets
- Determining kitchen lane hints

### Why this violates SRP

It violates SRP because allergen detection, cooking time estimation, and ticket formatting are different responsibilities.

## 7. LoanDesk

### Responsibilities

- Calculating loan risk scores
- Determining loan eligibility
- Generating required document lists
- Generating decision letters
- Exporting application data to CSV

### Why this violates SRP

It violates SRP because loan assessment, document requirements, decision letters, and CSV export are different responsibilities.

## 8. SubscriptionBilling

### Responsibilities

- Calculating prorated subscription charges
- Generating invoice numbers
- Tracking failed payments
- Generating dunning emails
- Generating accounting ledger entries

### Why this violates SRP

It violates SRP because billing calculations, invoice numbering, email generation, and accounting exports are different responsibilities.

## 9. SupportTicket

### Responsibilities

- Managing ticket information and customer messages
- Determining ticket priority from text
- Calculating SLA deadlines
- Checking SLA breaches
- Generating public replies
- Generating internal escalation messages

### Why this violates SRP

It violates SRP because priority detection, SLA management, and message generation are different responsibilities.

## 10. WarehousePickList

### Responsibilities

- Managing warehouse item requirements
- Allocating available stock
- Calculating the picking order
- Generating picker instructions
- Generating WMS XML batches

### Why this violates SRP

It violates SRP because stock allocation, picking routes, instructions, and XML generation are different responsibilities.

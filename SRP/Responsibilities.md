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

Feature: DropDpwns, Checkboxes y RadioButtons

#Background: El usuario Ingresa a sitio e inicia sesión. (pasos comunes a todos los TCs)

   @WebDriverUniversity @Checkbox @Estado
  Scenario Outline: Ver el valor del check 1

    Given el usuario ingresa al sitio de WebDriverUniversity
    When el usuario hace click en el primer checkbox sin chequear.
    Then el estado del primer checkbox deberia ser <valor>

    Examples: 
      | valor |
      | true  |
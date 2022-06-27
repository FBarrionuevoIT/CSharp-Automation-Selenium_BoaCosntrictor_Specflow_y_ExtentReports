Feature: Buscador de productos
   @TagsRelacionados
  Scenario Outline: Buscar en la seccion Women
    Given el usuario ingresa al sitio
    When el usuario inicia sesion con el usuario "<usuario>", la contraseña "<contraseña>" y voy al buscador en el apartado Women
    And el usuario realiza la busqueda de "<producto>"
    Then La cantidad de productos mostrados deberia ser mayor o igual que <cantidad>

    Examples: 
      | usuario                  | contraseña  | producto | cantidad |
      | fbarrionuevo@yopmail.com | yopmail2020 | Blouse   |        1 |
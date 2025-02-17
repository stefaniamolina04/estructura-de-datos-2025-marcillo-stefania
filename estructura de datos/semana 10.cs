import random

# Generar un conjunto de 500 ciudadanos ficticios
ciudadanos = {f'Ciudadano_{i}' for i in range(1, 501)}

# Generar un conjunto de 75 ciudadanos vacunados con Pfizer
vacunados_pfizer = set(random.sample(list(ciudadanos), 75))

# Generar un conjunto de 75 ciudadanos vacunados con AstraZeneca
vacunados_astrazeneca = set(random.sample(list(ciudadanos - vacunados_pfizer), 75))

# Listado de ciudadanos vacunados con ambas vacunas
vacunados_doble = vacunados_pfizer & vacunados_astrazeneca

# Listado de ciudadanos que no se han vacunado
no_vacunados = ciudadanos - (vacunados_pfizer | vacunados_astrazeneca)

# Listado de ciudadanos que han recibido las dos vacunas
solo_dos_vacunas = vacunados_doble

# Listado de ciudadanos que solamente han recibido la vacuna de Pfizer
solo_pfizer = vacunados_pfizer - vacunados_astrazeneca

# Listado de ciudadanos que solamente han recibido la vacuna de AstraZeneca
solo_astrazeneca = vacunados_astrazeneca - vacunados_pfizer

# Imprimir resultados
print(f'Ciudadanos no vacunados: {len(no_vacunados)}')
print(f'Ciudadanos con dos vacunas: {len(solo_dos_vacunas)}')
print(f'Ciudadanos solo con Pfizer: {len(solo_pfizer)}')
print(f'Ciudadanos solo con AstraZeneca: {len(solo_astrazeneca)}')

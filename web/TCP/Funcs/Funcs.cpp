// Funcs.cpp : Определяет экспортируемые функции для DLL.
//

#include "pch.h"
#include "framework.h"
#include "Funcs.h"


// Пример экспортированной переменной
FUNCS_API int nFuncs=0;

// Пример экспортированной функции.
FUNCS_API int fnFuncs(void)
{
    return 0;
}

// Конструктор для экспортированного класса.
CFuncs::CFuncs()
{
    return;
}

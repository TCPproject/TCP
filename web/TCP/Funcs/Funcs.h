﻿// Приведенный ниже блок ifdef — это стандартный метод создания макросов, упрощающий процедуру
// экспорта из библиотек DLL. Все файлы данной DLL скомпилированы с использованием символа FUNCS_EXPORTS
// Символ, определенный в командной строке. Этот символ не должен быть определен в каком-либо проекте,
// использующем данную DLL. Благодаря этому любой другой проект, исходные файлы которого включают данный файл, видит
// функции FUNCS_API как импортированные из DLL, тогда как данная DLL видит символы,
// определяемые данным макросом, как экспортированные.
#ifdef FUNCS_EXPORTS
#define FUNCS_API __declspec(dllexport)
#else
#define FUNCS_API __declspec(dllimport)
#endif

// Этот класс экспортирован из библиотеки DLL
class FUNCS_API CFuncs {
public:
	CFuncs(void);
	// TODO: добавьте сюда свои методы.
};

extern FUNCS_API int nFuncs;

FUNCS_API int fnFuncs(void);

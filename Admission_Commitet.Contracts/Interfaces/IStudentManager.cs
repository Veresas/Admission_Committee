using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Models;

namespace Contracts.Interfaces
{
    /// <summary>
    /// Управления данными
    /// </summary>
    public interface IStudentManager
    {
        /// <summary>
        /// Получение всех студентов из хранилища
        /// </summary>
        /// <returns>Результат вызова метода GetAll() класса хранилища</returns>
        Task<IReadOnlyCollection<Student>> GetAll();

        /// <summary>
        /// Добваление новых студентов в хранилище
        /// </summary>
        /// <param name="student"></param>
        /// <returns>Результат вызова метода Add() класса хранилища</returns>
        Task<Student> Add(Student student);

        /// <summary>
        /// Изменение существующего студента в хранилище
        /// </summary>
        /// <param name="student"></param>
        /// <returns>Результат вызова метода Edit() класса хранилища</returns>
        Task Edit(Student student);

        /// <summary>
        /// Удаление студента из хранилища
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Результат вызова метода Delet() класса хранилища</returns>
        Task<bool> Delete(Guid id);

        /// <summary>
        /// Получение статистики
        /// </summary>
        /// <returns>Класс представляющий статистику о студентах</returns>
        Task<IStudentStats> GetStats();
    }
}

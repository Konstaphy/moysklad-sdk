using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Confetti.MoySklad.Remap.Entities;

namespace Confetti.MoySklad.Remap.Client
{
    /// <summary>
    /// Represents the assertions to build the boolean API parameter.
    /// </summary>
    /// <typeparam name="TEntity">The concrete type of the meta entity.</typeparam>
    public class BooleanAssertions<TEntity> : AbstractAssertions where TEntity : MetaEntity
    {
                #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="BooleanAssertions{TEntity}" /> class
        /// with the parameter expression and the filters.
        /// </summary>
        /// <param name="parameter">The parameter expression.</param>
        /// <param name="filters">The filters.</param>
        protected internal BooleanAssertions(LambdaExpression parameter, List<FilterItem> filters)
            : base(parameter, filters)
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="BooleanAssertions{TEntity}" /> class
        /// with the parameter expression and the filters.
        /// </summary>
        /// <param name="parameter">The parameter expression.</param>
        /// <param name="filters">The filters.</param>
        internal BooleanAssertions(Expression<Func<TEntity, bool>> parameter, List<FilterItem> filters)
            : base(parameter, filters)
        {
        }
            
        #endregion

        #region Methods

        /// <summary>
        /// Asserts that a parameter should has the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <returns>The or constraint.</returns>
        public OrConstraint<BooleanAssertions<TEntity>> Be(bool value)
        {
            AddFilter(value.ToString().ToLower(), "=", new[] { "=" });
            return new OrConstraint<BooleanAssertions<TEntity>>(this);
        }

        /// <summary>
        /// Asserts that a parameter should not has the value.
        /// </summary>
        /// <param name="value">The value to assert.</param>
        /// <returns>The and constraint.</returns>
        public AndConstraint<BooleanAssertions<TEntity>> NotBe(bool value)
        {
            AddFilter(value.ToString().ToLower(), "!=", new[] { "!=" });
            return new AndConstraint<BooleanAssertions<TEntity>>(this);
        }
            
        #endregion
    }
}
namespace dymaptic.GeoBlazor.Core.Attributes
{
    /// <summary>
    ///     Add this property to any property on any subclass of <see cref="MapComponent" />, and if the user sets the dependent property, this property will be required. If the user forgets to set this property when the dependent property is set, this will throw a <see cref="MissingConditionallyRequiredChildElementException" />.
    /// </summary>
    public class ConditionallyRequiredPropertyAttribute : Attribute
    {
        /// <param name="dependentOn">
        ///     The name of the property that, when assigned, makes this property required.
        /// </param>
        public ConditionallyRequiredPropertyAttribute(string dependentOn)
        {
            DependentOn = dependentOn;
        }

        /// <summary>
        ///     The name of the property that, when assigned, makes this property required.
        /// </summary>
        public string DependentOn { get; }
    }
}
using PostSharp.Aspects;
using PostSharp.Aspects.Advices;
using PostSharp.Extensibility;
using PostSharp.Reflection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAccountModels.Common
{
    public class NotifyPropertyChangedAttribute : InstanceLevelAspect,
                                                     INotifyPropertyChanged
    {
        /// <summary>
        /// Field bound at runtime to a delegate of the method <c>OnPropertyChanged</c>.
        /// </summary>
        [ImportMember("OnPropertyChanged", IsRequired = false)]
        public Action<string> OnPropertyChangedMethod;

        /// <summary>
        /// Method introduced in the target type (unless it is already present);
        /// raises the <see cref="PropertyChanged"/> event.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        [IntroduceMember(Visibility = Visibility.Family, IsVirtual = true,
                          OverrideAction = MemberOverrideAction.Ignore)]
        public void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this.Instance,
                                       new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Event introduced in the target type (unless it is already present);
        /// raised whenever a property has changed.
        /// </summary>
        [IntroduceMember(OverrideAction = MemberOverrideAction.Ignore)]
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Method intercepting any call to a property setter.
        /// </summary>
        /// <param name="args">Aspect arguments.</param>
        [OnLocationSetValueAdvice,
         MulticastPointcut(Targets = MulticastTargets.Property,
             Attributes = MulticastAttributes.Instance)]
        public void OnPropertySet(LocationInterceptionArgs args)
        {
            // Don't go further if the new value is equal to the old one.
            // (Possibly use object.Equals here).
            if (args.Value == args.GetCurrentValue()) return;

            // Actually sets the value.
            args.ProceedSetValue();

            // Invoke method OnPropertyChanged (our, the base one, or the overridden one).
            this.OnPropertyChangedMethod.Invoke(args.Location.Name);

        }
    }
}

﻿// ComponentConfiguration.cs
//
// Circuit Diagram http://www.circuit-diagram.org/
//
// Copyright (C) 2012  Sam Fisher
//
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CircuitDiagram.Circuit;
using CircuitDiagram.Components;
using CircuitDiagram.Components.Description;

namespace CircuitDiagram.TypeDescription
{
    public class ComponentConfiguration
    {
        public string ImplementationName { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// A dictionary of setters with the serialized property name as the key.
        /// </summary>
        public Dictionary<PropertyName, PropertyValue> Setters { get; set; }

        public object Icon { get; set; }

        public ComponentConfiguration(string implementationName, string name, Dictionary<PropertyName, PropertyValue> setters)
        {
            ImplementationName = implementationName;
            Name = name;
            Setters = setters;
        }

        public bool Matches(Component component)
        {
            foreach (var setter in Setters)
            {
                if (!setter.Value.Equals(component.Properties[setter.Key]))
                    return false;
            }
            return true;
        }
    }
}
